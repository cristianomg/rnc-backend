using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Domain.Configs;
using Microsoft.Extensions.Options;
using Domain.Interfaces.Services;
using Domain.Dtos.Helps;

namespace Service.Services
{
    public class CreateAuthService : AbstractService, ICreateAuthService
    {
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly ICryptograph _cryptograph;
        private readonly string _jwtSecretKey;
        public CreateAuthService(IUserAuthRepository userAuthRepository,
                                 ICryptograph cryptograph,
                                 IOptions<CryptographConfig> cryptographConfig)
        {
            _userAuthRepository = userAuthRepository;
            _cryptograph = cryptograph;
            _jwtSecretKey = cryptographConfig.Value.JwtSecretKey;
        }
        public async Task<ResponseService<DtoCreateAuthResponse>> Execute(DtoCreateAuthInput dtoCreateAuth)
        {
            var existingAuth = await _userAuthRepository.GetByEmail(dtoCreateAuth.Email);

            if (existingAuth != null)
            {
                if (existingAuth.Active)
                {
                    var correctPassword = _cryptograph.VerifyPassword(dtoCreateAuth.Password, existingAuth.Password);

                    if (correctPassword)
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {

                            new Claim(ClaimTypes.Name, existingAuth.User.Name),
                            new Claim(ClaimTypes.Role, existingAuth.User.UserPermission.Name),

                            }),
                            Expires = DateTime.UtcNow.AddHours(3),

                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var token = tokenHandler.CreateToken(tokenDescriptor);

                        var user = new DtoUser
                        {
                            CompleteName = existingAuth.User.Name,
                            Email = existingAuth.Email,
                            Enrollment = existingAuth.User.Enrollment,
                            Setor = existingAuth.User.Setor,
                            Crbm = existingAuth.User.Crbm
                        };

                        var authResult = new DtoCreateAuthResponse { User = user, Token = tokenHandler.WriteToken(token), Permission = existingAuth.User.UserPermission.Name };


                        return GenerateSuccessServiceResponse(authResult);
                    }
                }
                return GenerateErroServiceResponse<DtoCreateAuthResponse>("Cadastro ainda não foi aprovado.");
            }
            return GenerateErroServiceResponse<DtoCreateAuthResponse>("Email ou senha invalidos.");
        }
    }
}

using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Application.Service
{
    public class SetorAppService : ISetorAppService
    {
        private readonly IMapper _mapper;
        private readonly ISetorRepository _setorRepository;

        public SetorAppService(ISetorRepository setorRepository, IMapper mapper)
        {
            _setorRepository = setorRepository;
            _mapper = mapper;
        }

        public async Task<DtoSetor> GetById(SetorType id)
        {
            var setor = await _setorRepository.GetById(id);
            return _mapper.Map<DtoSetor>(setor);
        }

        public async Task Update(DtoSetor dtoSetor)
        {
            var setor = new Setor()
            {
                Active = true,
                Id = dtoSetor.Id,
                Name = dtoSetor.Name
            };

            await _setorRepository.Update(setor);
            await _setorRepository.SaveChanges();
        }

        public async Task<IQueryable<DtoSetor>> GetAllSetor()
        {
            var setors = await _setorRepository.GetAllSetor();
            return _mapper.ProjectTo<DtoSetor>(setors);
        }
    }
}

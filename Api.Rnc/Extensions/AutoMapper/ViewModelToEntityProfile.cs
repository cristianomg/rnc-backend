using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Entities;

namespace Api.Rnc.Extensions.AutoMapper
{
    /// <summary>
    /// Responsável por registrar os mapeamentos de entidade para dto.
    /// </summary>
    public class ViewModelToEntityProfile : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ViewModelToEntityProfile()
        {
        }
    }
}

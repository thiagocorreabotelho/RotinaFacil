using AutoMapper;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Sexo, SexoDTO>().ReverseMap();
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        }
    }
}

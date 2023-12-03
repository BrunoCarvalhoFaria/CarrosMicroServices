using AutoMapper;
using Carros.Aluguel.Application.DTO;
using Carros.Aluguel.Domain.Entities;

namespace Carros.Aluguel.Application.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<EstoqueDTO, Estoque>().ReverseMap();
            CreateMap<FabricanteDTO, Fabricante>().ReverseMap();
            CreateMap<ModeloDTO, Modelo>().ReverseMap();
            CreateMap<EmprestimoDTO, Emprestimo>().ReverseMap();    
        }
    }
}

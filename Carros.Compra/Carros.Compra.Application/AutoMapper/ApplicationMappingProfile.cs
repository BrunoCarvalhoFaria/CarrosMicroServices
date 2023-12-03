using AutoMapper;
using Carros.Compra.Application.DTO;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Infra.Data.Mapping;

namespace Carros.Compra.Application.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() {
            CreateMap<ModeloDTO, Modelo>().ReverseMap();
            CreateMap<FabricanteDTO, Fabricante>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
        }
    }
}

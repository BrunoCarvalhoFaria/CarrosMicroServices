using AutoMapper;
using Carros.Compra.Api.ViewModel;
using Carros.Compra.Application.DTO;

namespace Carros.Compra.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile :  Profile
    {
        public ViewModelToDomainMappingProfile() {
            CreateMap<FabricanteViewModel, FabricanteDTO>().ReverseMap();
            CreateMap<ModeloPostViewModel, ModeloDTO>().ReverseMap();   
            CreateMap<PedidoPostViewModel, PedidoDTO>().ReverseMap();   
        }
    }
}

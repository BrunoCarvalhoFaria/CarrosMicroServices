using AutoMapper;
using Carros.Aluguel.Api.ViewModel;
using Carros.Aluguel.Application.DTO;

namespace Carros.Aluguel.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile :  Profile
    {
        public ViewModelToDomainMappingProfile() {
            CreateMap<ClienteViewModel, ClienteDTO>().ReverseMap();
        }
    }
}

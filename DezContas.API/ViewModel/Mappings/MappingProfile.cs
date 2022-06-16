using AutoMapper;
using DezContas.API.ViewModel;
using DezContas.Domain.Entities;
using PlayPedidos.API.ViewModel;

namespace PlayPedidos.API.DTOs.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Error, ErrorViewModel>().ReverseMap();
			CreateMap<ErrorDetails, ErrorDetailsViewModel>().ReverseMap();

			CreateMap<User, UserViewModel>().ReverseMap();
			CreateMap<User, UserPostViewModel>().ReverseMap();
			CreateMap<User, UserPutViewModel>().ReverseMap();
		}
	}
}

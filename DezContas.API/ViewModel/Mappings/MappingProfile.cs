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
			CreateMap<Account, AccountViewModel>().ReverseMap();
			CreateMap<Account, AccountPostViewModel>().ReverseMap();
			CreateMap<Account, AccountPutViewModel>().ReverseMap();

			CreateMap<Category, CategoryViewModel>().ReverseMap();
			CreateMap<Category, CategoryPostViewModel>().ReverseMap();
			CreateMap<Category, CategoryPutViewModel>().ReverseMap();

			CreateMap<Error, ErrorViewModel>().ReverseMap();
			CreateMap<ErrorDetails, ErrorDetailsViewModel>().ReverseMap();

			CreateMap<User, UserViewModel>().ReverseMap();
			CreateMap<User, UserPostViewModel>().ReverseMap();
			CreateMap<User, UserPutViewModel>().ReverseMap();
			CreateMap<User, UserLoginViewModel>().ReverseMap();
		}
	}
}

using AutoMapper;
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
		}
	}
}

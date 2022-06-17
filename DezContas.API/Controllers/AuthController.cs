using AutoMapper;
using DezContas.API.ViewModel;
using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PlayPedidos.API.ViewModel;

namespace DezContas.API.Controllers
{
	[Route("api/v1/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public AuthController(IMapper mapper, IUserService userService)
		{
			_mapper = mapper;
			_userService = userService;
		}

		[Route("register")]
		[HttpPost]
		public async Task<IActionResult> Register([FromBody] UserPostViewModel userViewModel)
		{
			var user = _mapper.Map<User>(userViewModel);

			if (user == null)
				return BadRequest();

			if (!user.IsValid())
				return BadRequest(_mapper.Map<ErrorViewModel>(user.GetErrors()));

			user.Password = user.HashPassword(user.Password);

			await _userService.Add(user);

			var newUserViewModel = _mapper.Map<UserViewModel>(user);
			return RedirectToAction("GetById", "User", new { id = newUserViewModel.Id });
		}
	}
}

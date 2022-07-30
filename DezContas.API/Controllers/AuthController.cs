using AutoMapper;
using DezContas.API.ViewModel;
using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPedidos.API.ViewModel;

namespace DezContas.API.Controllers;
[Route("api/v1/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IAuthService _authService;
  private readonly IUserService _userService;

  public AuthController(IMapper mapper, IAuthService authService, IUserService userService)
  {
    _mapper = mapper;
    _authService = authService;
    _userService = userService;
  }

  [Route("register")]
  [HttpPost]
  public async Task<IActionResult> Register([FromBody] UserPostViewModel userViewModel)
  {
    var user = _mapper.Map<User>(userViewModel);

    if (user == null)
      return BadRequest();

    if (!(user.IsValid() && await _userService.ValidateIfExistUsernameAndEmail(user)))
      return BadRequest(_mapper.Map<ErrorViewModel>(user.GetErrors()));

    user.HashPassword();
    user.Activate();

    await _userService.Add(user);

    var newUserViewModel = _mapper.Map<UserViewModel>(user);
    return Ok(newUserViewModel);
  }

  [Route("login")]
  [HttpPost]
  public async Task<ActionResult<dynamic>> Login([FromBody] UserLoginViewModel userViewModel)
  {
    var user = _mapper.Map<User>(userViewModel);
    var loggin = await _authService.Login(user);
    if (loggin != null)
      return Ok(loggin);

    return NotFound(new { error = "Invalid username or password." });
  }
}

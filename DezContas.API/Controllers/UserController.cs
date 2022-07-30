using AutoMapper;
using DezContas.API.ViewModel;
using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPedidos.API.ViewModel;

namespace DezContas.API.Controllers
{
  [Route("api/v1/user")]
  [ApiController]
  [Authorize]
  public class UserController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
      _mapper = mapper;
      _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var users = await _userService.Get();

      var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);

      return Ok(usersViewModel);
    }

    [HttpGet("{id}", Name = nameof(GetUserById))]
    public async Task<IActionResult> GetUserById(Guid id)
    {
      var user = await _userService.GetSingle(x => x.Id == id);

      var viewModel = _mapper.Map<UserViewModel>(user);

      if (viewModel == null)
        NotFound();

      return Ok(viewModel);
    }

    [HttpPut("{id}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
    public async Task<IActionResult> PutById(Guid id, [FromBody] UserPutViewModel userViewModel)
    {
      if (id != userViewModel.Id)
        return BadRequest();

      var existingUser = await _userService.GetSingle(x => x.Id == id);
      if (existingUser == null)
        return BadRequest();

      var user = _mapper.Map<User>(userViewModel);
      if (!user.IsValid())
        return BadRequest(_mapper.Map<ErrorViewModel>(user.GetErrors()));

      await _userService.Edit(user);

      var editedUserViewModel = _mapper.Map<UserViewModel>(user);
      return Ok(editedUserViewModel);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteById(Guid id)
    {
      var user = await _userService.GetSingle(x => x.Id == id);

      if (user == null)
        return BadRequest();

      await _userService.Delete(user);

      return NoContent();
    }
  }
}

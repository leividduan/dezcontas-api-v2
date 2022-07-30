using AutoMapper;
using DezContas.API.Helpers;
using DezContas.API.ViewModel;
using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPedidos.API.ViewModel;

namespace DezContas.API.Controllers;
[Route("api/v1/account")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IAccountService _accountService;

  public AccountController(IMapper mapper, IAccountService accountService)
  {
    _mapper = mapper;
    _accountService = accountService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var accounts = await _accountService.Get();

    var accountsViewModel = _mapper.Map<IEnumerable<AccountViewModel>>(accounts);

    return Ok(accountsViewModel);
  }

  [HttpGet("{id}", Name = nameof(GetAccountById))]
  public async Task<IActionResult> GetAccountById(Guid id)
  {
    var account = await _accountService.GetSingle(x => x.Id == id);

    var viewModel = _mapper.Map<AccountViewModel>(account);

    if (viewModel == null)
      NotFound();

    return Ok(viewModel);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] AccountPostViewModel accountViewModel)
  {
    var account = _mapper.Map<Account>(accountViewModel);

    if (account == null)
      return BadRequest();

    if (!account.IsValid())
      return BadRequest(_mapper.Map<ErrorViewModel>(account.GetErrors()));

    var idUser = HttpContext.User.Claims.GetUserIdClaim();
    account.AssociateIdUser(idUser);

    await _accountService.Add(account);

    var newAccountViewModel = _mapper.Map<AccountViewModel>(account);
    return Ok(newAccountViewModel);
  }

  [HttpPut("{id}")]
  [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
  public async Task<IActionResult> PutById(Guid id, [FromBody] AccountPutViewModel accountViewModel)
  {
    if (id != accountViewModel.Id)
      return BadRequest();

    var existingAccount = await _accountService.GetSingle(x => x.Id == id);
    if (existingAccount == null)
      return BadRequest();

    var account = _mapper.Map<Account>(accountViewModel);

    if (!account.IsValid())
      return BadRequest(_mapper.Map<ErrorViewModel>(account.GetErrors()));

    var idUser = HttpContext.User.Claims.GetUserIdClaim();
    account.AssociateIdUser(idUser);

    await _accountService.Edit(account);

    var editedAccountViewModel = _mapper.Map<AccountViewModel>(account);
    return Ok(editedAccountViewModel);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteById(Guid id)
  {
    var account = await _accountService.GetSingle(x => x.Id == id);

    if (account == null)
      return BadRequest();

    await _accountService.Delete(account);

    return NoContent();
  }
}

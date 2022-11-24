using AutoMapper;
using DezContas.API.Helpers;
using DezContas.API.ViewModel;
using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    var accountsViewModel = _mapper.Map<IEnumerable<AccountViewModel>>(accounts.OrderBy(x => x.CreatedAt));

    return Ok(accountsViewModel);
  }

  [HttpGet("{id:guid}", Name = nameof(GetAccountById))]
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

    var idUser = HttpContext.User.Claims.GetUserIdClaim();
    account.AssociateIdUser(idUser);

    if (!account.IsValid())
      return BadRequest(_mapper.Map<ErrorViewModel>(account.GetErrors()));

    await _accountService.Add(account, account.IsDefault);

    var newAccountViewModel = _mapper.Map<AccountViewModel>(account);
    return Ok(newAccountViewModel);
  }

  [AcceptVerbs("COPY")]
  [Route("{id:guid}")]
  public async Task<IActionResult> Duplicate(Guid id)
  {
    var idUser = HttpContext.User.Claims.GetUserIdClaim();

    var account = await _accountService.GetSingle(x => x.Id == id && x.UserId == idUser);
    if (account == null)
      return NotFound();

    account.Duplicate();
    await _accountService.Add(account);

    var accountViewModel = _mapper.Map<AccountViewModel>(account);

    return Ok(accountViewModel);
  }

  [HttpPut("{id:guid}")]
  [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
  public async Task<IActionResult> PutById(Guid id, [FromBody] AccountPutViewModel accountViewModel)
  {
    if (id != accountViewModel.Id)
      return BadRequest();

    var idUser = HttpContext.User.Claims.GetUserIdClaim();

    var existingAccount = await _accountService.GetSingle(x => x.Id == id && x.UserId == idUser);
    if (existingAccount == null)
      return BadRequest();

    existingAccount.AssociateIdUser(idUser);
    existingAccount.Edit(accountViewModel.Name, accountViewModel.Description, accountViewModel.IsDefault, accountViewModel.IsActive, accountViewModel.Type);

    if (!existingAccount.IsValid())
      return BadRequest(_mapper.Map<ErrorViewModel>(existingAccount.GetErrors()));

    await _accountService.Edit(existingAccount, true);

    var editedAccountViewModel = _mapper.Map<AccountViewModel>(existingAccount);
    return Ok(editedAccountViewModel);
  }

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> DeleteById(Guid id)
  {
    var account = await _accountService.GetSingle(x => x.Id == id);

    if (account == null)
      return BadRequest();

    await _accountService.Delete(account);

    return NoContent();
  }
}

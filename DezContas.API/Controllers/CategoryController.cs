using AutoMapper;
using DezContas.API.Helpers;
using DezContas.API.ViewModel;
using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DezContas.API.Controllers;

[Route("api/v1/category")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly ICategoryService _categoryService;

  public CategoryController(IMapper mapper, ICategoryService categoryService)
  {
    _mapper = mapper;
    _categoryService = categoryService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var categories = await _categoryService.Get();

    var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories.OrderBy(x => x.CreatedAt));

    return Ok(categoriesViewModel);
  }

  [HttpGet("{id:guid}", Name = nameof(GetCategoryById))]
  public async Task<IActionResult> GetCategoryById(Guid id)
  {
    var category = await _categoryService.GetSingle(x => x.Id == id);

    var viewModel = _mapper.Map<CategoryViewModel>(category);

    if (viewModel == null)
      NotFound();

    return Ok(viewModel);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CategoryPostViewModel categoryViewModel)
  {
    var category = _mapper.Map<Category>(categoryViewModel);

    if (category == null)
      return BadRequest();

    var idUser = HttpContext.User.Claims.GetUserIdClaim();
    category.AssociateIdUser(idUser);

    if (!category.IsValid())
      return BadRequest(_mapper.Map<ErrorViewModel>(category.GetErrors()));

    await _categoryService.Add(category);

    var newCategoryViewModel = _mapper.Map<CategoryViewModel>(category);
    return Ok(newCategoryViewModel);
  }

  [HttpPut("{id:guid}")]
  [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
  public async Task<IActionResult> PutById(Guid id, [FromBody] CategoryPutViewModel categoryViewModel)
  {
    if (id != categoryViewModel.Id)
      return BadRequest();

    var idUser = HttpContext.User.Claims.GetUserIdClaim();

    var existingCategory = await _categoryService.GetSingle(x => x.Id == id && x.UserId == idUser);
    if (existingCategory == null)
      return BadRequest();

    existingCategory.AssociateIdUser(idUser);
    existingCategory.Edit(categoryViewModel.Name, categoryViewModel.Description, categoryViewModel.IsActive, categoryViewModel.Type);

    if (!existingCategory.IsValid())
      return BadRequest(_mapper.Map<ErrorViewModel>(existingCategory.GetErrors()));

    await _categoryService.Edit(existingCategory);

    var editedCategoryViewModel = _mapper.Map<CategoryViewModel>(existingCategory);
    return Ok(editedCategoryViewModel);
  }

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> DeleteById(Guid id)
  {
    var category = await _categoryService.GetSingle(x => x.Id == id);

    if (category == null)
      return BadRequest();

    await _categoryService.Delete(category);

    return NoContent();
  }
}
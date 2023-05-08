using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		[ProducesResponseType(200)]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
		{
			var result = await _categoryService.GetCategories();
			return Ok(result);
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly DataContext _context;

		public ProductController(DataContext context)
		{
			_context = context;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var products = await _context.Products.ToListAsync();
			return Ok(products);
		}
	}
}

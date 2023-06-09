﻿using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
			;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
		{
			var result = await _productService.GetProductsAsync();
			return Ok(result);
		}

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int id)
        {
            var result = await _productService.GetProductAsync(id);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
	        var result = await _productService.GetProductsByCategory(categoryUrl);
	        return Ok(result);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText, int page = 1)
        {
	        var result = await _productService.SearchProducts(searchText, page);
	        return Ok(result);
        }
        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearch(string searchText)
        {
	        var result = await _productService.GetProductSearchSuggestions(searchText);
	        return Ok(result);
        }
        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
	        var result = await _productService.GetFeaturedProducts();
	        return Ok(result);
        }
	}
}

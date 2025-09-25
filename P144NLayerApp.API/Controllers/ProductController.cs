using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using P144NLayerApp.BusinessLayer.DTO;
using P144NLayerApp.BusinessLayer.Interface;
using Serilog;


namespace P144NLayerApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _env = environment;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() //start
        {
            Log.Information(nameof(GetAll) + " method call! ");
            return Ok(await _productService.GetAll());
        }

        [HttpPost]
        public async Task Create(ProductPostDto product)
        {
            await _productService.Create(product, _env.WebRootPath);
        }

        [HttpGet]
        public async Task<IActionResult> GetFileById(int id)
        {
            var result = await _productService.GetFileById(id, _env.WebRootPath);
            return File(result, MediaTypeNames.Image.Jpeg, "product.jpg");
        }
    }
}

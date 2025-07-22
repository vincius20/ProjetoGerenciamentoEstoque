using Microsoft.AspNetCore.Mvc;
using ServicesContracts;
using ServicesContracts.DTO;

namespace ProjetoGerenciamentoEstoque.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        [Route("[action]")]
        public async Task<IActionResult> AllProducts()
        {
            var listProducts = await _productsService.GetAllProducts();
           
            return View(listProducts);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var list = await _categoriesService.GetAllCategories();
            ViewBag.Categories = list;
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddRequest productAddRequest)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            //ProductResponse
            ProductResponse productResponse = await _productsService.AddProduct(productAddRequest);

            return RedirectToAction(nameof(ProductsController.AllProducts), "Products");
        }
    }
}

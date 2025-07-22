using Microsoft.AspNetCore.Mvc;
using ServicesContracts;
using ServicesContracts.DTO;

namespace ProjetoGerenciamentoEstoque.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [Route("[action]")]
        public async Task<IActionResult> AllCategories()
        {
            var list = await _categoriesService.GetAllCategories();
            return View(list);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddRequest categoryAddRequest)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            //CategoryResponse
            CategoryResponse categoryResponse = await _categoriesService.AddCategory(categoryAddRequest);

            return RedirectToAction(nameof(CategoriesController.AllCategories),"Categories");
        }
    }
}

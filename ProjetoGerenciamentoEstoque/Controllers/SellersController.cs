using Microsoft.AspNetCore.Mvc;

namespace ProjetoGerenciamentoEstoque.Controllers
{
    [Route("[controller]")]
    public class SellersController : Controller
    {
        [Route("[action]")]
        public IActionResult AllSellers()
        {
            return View();
        }
    }
}

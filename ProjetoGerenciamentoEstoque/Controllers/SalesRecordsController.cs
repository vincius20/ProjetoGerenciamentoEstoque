using Microsoft.AspNetCore.Mvc;

namespace ProjetoGerenciamentoEstoque.Controllers
{
    [Route("[controller]")]
    public class SalesRecordsController : Controller
    {
        [Route("[action]")]
        public IActionResult AllSales()
        {
            return View();
        }
    }
}

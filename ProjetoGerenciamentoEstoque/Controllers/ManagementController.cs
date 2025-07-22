using Microsoft.AspNetCore.Mvc;

namespace ProjetoGerenciamentoEstoque.Controllers
{
    [Route("[controller]")]
    public class ManagementController : Controller
    {        
        [Route("[action]")]
        [Route("/")]
        public IActionResult Index()
        { 
            return View();
        }
           
    }
}

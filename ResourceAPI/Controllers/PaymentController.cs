using Microsoft.AspNetCore.Mvc;

namespace ResourceAPI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

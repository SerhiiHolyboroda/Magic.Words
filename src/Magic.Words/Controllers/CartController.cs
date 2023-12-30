using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class CartController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}

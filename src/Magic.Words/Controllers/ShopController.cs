using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class ShopController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}

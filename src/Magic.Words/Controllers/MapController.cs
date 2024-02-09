using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class MapController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}

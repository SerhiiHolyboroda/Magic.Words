using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Magic.Words.Web.Controllers {
    public class DeskController : Controller {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly IServiceProvider _serviceProvider;

        public DeskController(IRazorViewEngine razorViewEngine, IServiceProvider serviceProvider) {
            _razorViewEngine = razorViewEngine;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index() {
            // Find the Razor page
            var viewResult = _razorViewEngine.GetView("~/Views/Shared", "/Index.razor", false);
            if (viewResult.Success)
            {
                // Render the Razor page to a string
                using (var sw = new StringWriter())
                {
                    var viewContext = new ViewContext(
                        new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor),
                        viewResult.View,
                        ViewData,
                        TempData,
                        sw,
                        new HtmlHelperOptions()
                    );
                    await viewResult.View.RenderAsync(viewContext);
                    var renderedContent = sw.ToString();

                    // Return the rendered content as a string
                    return Content(renderedContent, "text/html");
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
    
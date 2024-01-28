using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
 
namespace  Magic.Words.Web.Areas.Customer.Controllers
{
   // [Area("Customer")]
    //  [Area("Admin")]
    // [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUserRepository.GetAll()
   //   .OrderByDescending(u => u.Rating)
   //    .Take(50)
   .ToList();

            return View(objUserList);
        }

    /*    [HttpGet]
        public IActionResult GetAll() {
        List<ApplicationUser> objUserList = _unitOfWork.ApplicationUserRepository.GetAll()
  
        }

        */
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MaisSabor2.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        
        [Area ("Admin")]
        [Authorize(Roles="Admin")]
        public IActionResult Index (){
         return View();
        }
    }
}
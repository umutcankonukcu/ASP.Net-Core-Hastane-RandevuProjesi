using HastaneProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneProjesi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied() 
        {
            return View();
        }
    }
}
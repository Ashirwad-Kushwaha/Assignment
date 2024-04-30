using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult GetAccount()
        {
            return View();
        }


        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View("GetAccount");
            }
            return RedirectToAction("Index", "todolists");
        }
    }
}

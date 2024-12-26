using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;
using TaskManagement.Models.ViewModels;

namespace TaskManagement.Controllers
{
    public class LoginController : Controller
    {
        AppDbContext context=new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult direct(LoginVM loginVM)
        {
            if (loginVM.category == "1")
            {
                var valid = context.Admins.FirstOrDefault(x => x.Password == loginVM.Password);
                if (valid != null)
                {
                    return RedirectToAction("Index", "Admin",valid);
                }
                else
                {
                    return RedirectToAction("Index", "Home", loginVM);
                }
            }
            else if (loginVM.category == "2")
            {
                var valid = context.SuperVisors.FirstOrDefault(x => x.Password == loginVM.Password);
                if (valid.Password != null)
                {
                    return RedirectToAction("Index", "Admin"); // superdashboard
                }
                else
                {
                    return RedirectToAction("Index", "Home", loginVM);
                }
            }
            else if (loginVM.category == "3")
            {
                var valid = context.Employees.FirstOrDefault(x => x.Password == loginVM.Password);
                if (valid.Password != null)
                {
                    return RedirectToAction("Index", "Admin"); // employee dashboard
                }
                else
                {
                    return RedirectToAction("Index", "Home", loginVM);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", loginVM);
            }

        }
    }
}

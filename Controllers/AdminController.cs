using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using TaskManagement.Models.ViewModels;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext context = new AppDbContext();
        public IActionResult Index(Admin admin)
        {
            ViewBag.Employees = context.Employees.ToList();
            ViewBag.Supervisors = context.SuperVisors.ToList();
            ViewBag.BigTasks = context.BigTasks.ToList();
            ViewBag.SubTasks = context.SubTasks.ToList();

            return View(admin);
        }
        public IActionResult AddEmployee()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.SuperVisors = context.SuperVisors.ToList();
            return View();
        }
        public IActionResult SaveEmployee(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult AddTask()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.SuperVisors = context.SuperVisors.ToList();
            return View();
        }
        public IActionResult SaveTask(BigTask btask)
        {
            context.BigTasks.Add(btask);
            context.SaveChanges();
            return RedirectToAction("Index");
        } 
        public IActionResult AddSuperVisor()
        {
            ViewBag.Departments = context.Departments.ToList();
            return View();
        }
        public IActionResult SaveSuperVisor(SuperVisor super)
        {
            context.SuperVisors.Add(super);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddEmployee");
        }
    }
}

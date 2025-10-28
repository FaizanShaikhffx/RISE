using System.Diagnostics;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDBContext employeeDB;
        public HomeController(EmployeeDBContext employeeDB)
        {
            this.employeeDB = employeeDB;
        }

        public IActionResult Index()
        {
            var stdData = employeeDB.Employees2.ToList();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid) { 
            await employeeDB.Employees2.AddAsync(emp); 
            await employeeDB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || employeeDB.Employees2 == null)
            {
                return NotFound();
            }
            var empData = await employeeDB.Employees2.FindAsync(id); 
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Employee emp)
        {
            if (id != emp.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeDB.Employees2.Update(emp);
                await employeeDB.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || employeeDB.Employees2 == null)
            {
                return NotFound();
            }
            var empData = employeeDB.Employees2.FirstOrDefault(e => e.Id == id);
            return View(empData);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || employeeDB.Employees2 == null)
            {
                return NotFound();
            }
            var empData = employeeDB.Employees2.FirstOrDefault(e => e.Id == id);
            return View(empData);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id == null || employeeDB.Employees2 == null)
            {
                return NotFound();
            }
            var empData = employeeDB.Employees2.FirstOrDefault(e => e.Id == id);
            if (empData != null)
            {
                employeeDB.Employees2.Remove(empData);
                employeeDB.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(empData);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

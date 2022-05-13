using LoginWebForm.Areas.Identity.Data;
using LoginWebForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginWebForm.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _DB;
        public DepartmentController(ApplicationDbContext Db)
        {
            _DB = Db;
        }
        public IActionResult DepartmentList(string SearchText = "")
        {
            List<Department> emp;
            if (SearchText != "" & SearchText != null)
            {
                emp = _DB.tbl_Department
                    .Where(e => e.Name.Contains(SearchText)).ToList();
            }
            else

                emp = _DB.tbl_Department.ToList();

            return View(emp);
            //List<Department> dep;
            //dep = _DB.tbl_Department.ToList();
            //return View(dep);
            //return View();
        }
        
        [HttpGet]
        public IActionResult Create(Department obj)
        {
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department obj)
        {
            try
            {
                if (obj.ID == 0)
                {
                    _DB.tbl_Department.Add(obj);
                    await _DB.SaveChangesAsync();

                }
                else
                {
                    _DB.Entry(obj).State = EntityState.Modified;
                    await _DB.SaveChangesAsync();
                }
                return RedirectToAction("DepartmentList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("DepartmentList");

            }
        }

        public IActionResult DepartmentDetail(int Id)
        {
            Department emp = _DB.tbl_Department.Where(x => x.ID == Id).FirstOrDefault();
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Department obj = _DB.tbl_Department.Where(p => p.ID == Id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Department obj)
        {
            _DB.Attach(obj);
            _DB.Entry(obj).State = EntityState.Deleted;
            _DB.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
    }
}

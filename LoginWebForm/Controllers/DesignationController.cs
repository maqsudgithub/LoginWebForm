using LoginWebForm.Areas.Identity.Data;
using LoginWebForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginWebForm.Controllers
{
    [Authorize]
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _DB;
        public DesignationController(ApplicationDbContext Db)
        {
            _DB = Db;
        }
        public IActionResult DesignatonList()
        {
            List<Designation> dep;
            dep = _DB.tbl_Designation.ToList();
            return View(dep);
            return View();
        }


        [HttpGet]
        public IActionResult Create(Designation obj)
        {
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddDesignaiton(Designation obj)
        {
            try
            {
                if (obj.ID == 0)
                {
                    _DB.tbl_Designation.Add(obj);
                    await _DB.SaveChangesAsync();

                }
                else
                {
                    _DB.Entry(obj).State = EntityState.Modified;
                    await _DB.SaveChangesAsync();
                }
                return RedirectToAction("DesignatonList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("DesignatonList");

            }
        }

        public IActionResult DesignationDetail(int Id)
        {
            Designation emp = _DB.tbl_Designation.Where(x => x.ID == Id).FirstOrDefault();
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Designation obj = _DB.tbl_Designation.Where(p => p.ID == Id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Designation obj)
        {
            _DB.Attach(obj);
            _DB.Entry(obj).State = EntityState.Deleted;
            _DB.SaveChanges();
            return RedirectToAction("DesignatonList");
        }
    }
}

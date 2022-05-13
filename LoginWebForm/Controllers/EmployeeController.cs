using LoginWebForm.Areas.Identity.Data;
using LoginWebForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginWebForm.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _DB;
        private readonly IWebHostEnvironment _webHost;
        public EmployeeController(ApplicationDbContext Db, IWebHostEnvironment webHost)
        {
            _DB = Db;
            this._webHost = webHost;
        }

        public IActionResult EmployeeList()
        {
            try
            {
                var stdlist = from a in _DB.tbl_Employee
                              join b in _DB.tbl_Department
                              on a.DepID equals b.ID
                              join c in _DB.tbl_Designation
                              on a.DesID equals c.ID
                              into Emp
                              from c in Emp.DefaultIfEmpty()
                              select new Employee
                              {
                                  ID = a.ID,
                                  DepID = a.DepID,
                                  DesID = a.DesID,
                                  Name = a.Name,
                                  FName = a.FName,
                                  Email = a.Email,
                                  Contact=a.Contact,
                                  Date = a.Date,
                                  Image = a.Image,
                                  Department = b == null ? null : b.Name,
                                  Designation = c == null ? null : c.Name,

                              };

                return View(stdlist);
            }
            catch (Exception ex)
            {

                return View();
            }
            //List<Employee> emp;
            //if (SearchText != "" & SearchText != null)
            //{
            //    emp = _DB.tbl_Employee
            //        .Where(e => e.Name.Contains(SearchText)).ToList();
            //}
            //else

            //    emp = _DB.tbl_Employee.ToList();

            //return View(emp);
        }

        [HttpGet]
        public IActionResult Create(Employee obj)
        {
            loadDEP();
            loadDES();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj, IFormFile images)
        {
            try
            {
                string uniquefilename = string.Empty;
                if (images != null)
                {
                    string uploadsfolder = Path.Combine(_webHost.WebRootPath, "images");
                    uniquefilename = Guid.NewGuid().ToString() + "_" + images.FileName;
                    string filePath = Path.Combine(uploadsfolder, uniquefilename);
                    images.CopyTo(new FileStream(filePath, FileMode.Create));
                    obj.Image = uniquefilename;
                }
                if (obj.ID == 0)
                {
                    _DB.tbl_Employee.Add(obj);
                    await _DB.SaveChangesAsync();
                }
                else
                {
                    _DB.Entry(obj).State = EntityState.Modified;
                    await _DB.SaveChangesAsync();
                }
                return RedirectToAction("EmployeeList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EmployeeList");

            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Employee obj = _DB.tbl_Employee.Where(p => p.ID == Id).FirstOrDefault();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Employee obj)
        {
            _DB.Attach(obj);
            _DB.Entry(obj).State = EntityState.Deleted;
            _DB.SaveChanges();
            return RedirectToAction("EmployeeList");
        }



        public IActionResult EmployeeDetail(int Id)
        {
            Employee emp = _DB.tbl_Employee.Where(x => x.ID == Id).FirstOrDefault();
            return View(emp);
        }



        private void loadDEP()
        {
            try
            {
                List<Department> deplist = new List<Department>();
                deplist = _DB.tbl_Department.ToList();
                deplist.Insert(0, new Department { ID = 0, Name = "Please Select" });
                ViewBag.DepList = deplist;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private void loadDES()
        {
            try
            {
                List<Designation> deslist = new List<Designation>();
                deslist = _DB.tbl_Designation.ToList();
                deslist.Insert(0, new Designation { ID = 0, Name = "Please Select" });
                ViewBag.DesList = deslist;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

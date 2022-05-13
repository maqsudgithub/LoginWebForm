using LoginWebForm.Areas.Identity.Data;
using LoginWebForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginWebForm.Controllers
{
    [Authorize]
    public class User : Controller
    {
        private readonly ApplicationDbContext _DB;
        public User(ApplicationDbContext Db)
        {
            _DB = Db;
        }
        public IActionResult List()
        {
            UserModel obj = new UserModel();
            var data = obj.GetUser();
            return View(data);
        }


        [HttpGet]
        public IActionResult Create(UserModel obj)
        {
            return View(obj);
        }
        

    }
}

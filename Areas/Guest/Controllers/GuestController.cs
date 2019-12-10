using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCase.Areas.Guest.Models;
using TestCase.Data;
using TestCase.Models.ViewModel;

namespace TestCase.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GuestController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(LoginModel1 signin1)
        {
            if (ModelState.IsValid) // Kiểm tra người dùng đã nhập đầy đủ thông tin chưa
            {
                var CheckLogin12 = _db.UsersGuests.Where(x => x.UserName.Equals(signin1.UserName)
                && x.Password.Equals(signin1.Password)).FirstOrDefault(); //lấy thông tin user và password để kiểm tra login

                if (CheckLogin12 != null)//Nếu người dùng nhập đúng tài khoản và mật khẩu 
                {
                    if (signin1.UserName == "hkt" && signin1.Password == "1234") //Nếu người dùng có tên tài khoản là hkt thì là admin  
                    {
                        return RedirectToAction("Index", "Products", new { area = "Admin" });
                    }
                    else if (signin1.UserName != "hkt")//Nếu người dùng khác tên tài khoản hkt thì là admin
                    {
                        HttpContext.Session.SetInt32("AccountId", CheckLogin12.Id);//lưu lại phiên làm việc của người dùng dưới dạng Id
                    }
                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
                else if (CheckLogin12 == null)
                {
                    return View(signin1);
                }
            }
            return View(signin1);
        }
        public IActionResult AccountInformation1()
        {

            var Id = HttpContext.Session.GetInt32("AccountId");
            var AccUser = _db.UsersGuests.Find(Id);
            if (AccUser == null)
            {
                return RedirectToAction("Login1", "Guest");
            }
            ViewBag.Id = AccUser.Id;
            ViewBag.Name = AccUser.Name;
            ViewBag.Username = AccUser.UserName;
            ViewBag.Password = AccUser.Password;
            ViewBag.Email = AccUser.Email;
            ViewBag.Phone = AccUser.Phone;

            return View();
        }
    }
}
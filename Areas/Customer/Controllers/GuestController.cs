using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCase.Data;
using TestCase.Models;
using TestCase.Models.ViewModel;

namespace TestCase.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GuestController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult RegisterSuccessfull1()
        {
            return View();
        }
        public IActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(LoginModel3 signin1)
        {
            if (ModelState.IsValid) // Kiểm tra người dùng đã nhập đầy đủ thông tin chưa
            {
                var CheckLogin12 = _db.UsersGuests.Where(x => x.UserName.Equals(signin1.UserName) 
                && x.Password.Equals(signin1.Password)).FirstOrDefault(); //lấy thông tin user và password để kiểm tra login

                if (CheckLogin12 != null)//Nếu người dùng nhập đúng tài khoản và mật khẩu 
                {
                    if (signin1.UserName == "hkt") //Nếu người dùng có tên tài khoản là hkt thì là admin  
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
        [HttpGet]
        public IActionResult Logout()
        {
            int value = -1;
            HttpContext.Session.SetInt32("AccountId", value);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFromDb = await _db.UsersGuests.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsersGuests applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(applicationUser);
                await _db.SaveChangesAsync();
                return RedirectToAction("AccountInformation1", "Guest");
            }

            return View(applicationUser);
        }
        public IActionResult AccountInformation1()
        {

            var Id = HttpContext.Session.GetInt32("AccountId");//lấy Id của người dùng 
            var AccUser = _db.UsersGuests.Find(Id);//Lấy thông tin của người dùng
            if (AccUser == null)//Kiểm tra xem người dùng đã đăng nhập chưa
            {
                return RedirectToAction("Login1", "Guest");//Nếu chưa đăng nhập sẽ chuyển đến trang đăng nhập
            }
            //dùng ViewData để chuyển thông tin  từ controller lên view
            ViewData["Id"] = AccUser.Id;
            ViewData["Name"] = AccUser.Name;
            ViewData["UserName"] = AccUser.UserName;
            ViewData["Password"] = AccUser.Password;
            ViewData["Email"] = AccUser.Email;
            ViewData["Phone"] = AccUser.Phone;

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UsersGuests user1)
        {
            if(ModelState.IsValid==null)
            {
                return View(user1);
            }
            else if(ModelState.IsValid)
            {
                _db.Add(user1);
                await _db.SaveChangesAsync();
                return RedirectToAction("RegisterSuccessfull1", "Guest");
            }
            return View(user1);
        }
    }
}
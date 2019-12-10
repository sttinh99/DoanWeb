using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCase.Data;
using TestCase.Extensions;
using TestCase.Models;
using TestCase.Models.ViewModel;

namespace TestCase.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        static double ReceiptBill = 0;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Models.Products>()
            };
        }
        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            //if(lstShoppingCart.Count == 0)
            //{

            //}
            //else 
            if (lstShoppingCart.Count > 0)
            {
                foreach (int cartItem in lstShoppingCart)
                {
                    Products prod = _db.Products.Include(p => p.ProductTypes).Where(p => p.Id == cartItem).FirstOrDefault();
                    ShoppingCartVM.Products.Add(prod);
                    ReceiptBill += prod.Price;//hàm thêm giá tiền sản phẩm
                }
            }
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            ShoppingCartVM.Appointments.AppointmentDate = ShoppingCartVM.Appointments.AppointmentDate
                                                            .AddHours(ShoppingCartVM.Appointments.AppointmentTime.Hour)
                                                            .AddMinutes(ShoppingCartVM.Appointments.AppointmentTime.Minute);

            Appointments appointments = ShoppingCartVM.Appointments;
            appointments.Recceipt = ReceiptBill;
            _db.Appointments.Add(appointments);
            _db.SaveChanges();

            int appointmentId = appointments.Id;

            foreach (int productId in lstCartItems)
            {
                ProductsSelectedForAppointment productsSelectedForAppointment = new ProductsSelectedForAppointment()
                {
                    AppointmentId = appointmentId,
                    ProductId = productId
                };
                _db.ProductsSelectedForAppointments.Add(productsSelectedForAppointment);

            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction("AppointmentConfirmation", "ShoppingCart", new { Id = appointmentId });

        }
        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult AppointmentConfirmation(int id)
        {
            ShoppingCartVM.Appointments = _db.Appointments.Where(a => a.Id == id).FirstOrDefault();
            List<ProductsSelectedForAppointment> objProdList = _db.ProductsSelectedForAppointments.Where(p => p.AppointmentId == id).ToList();

            foreach (ProductsSelectedForAppointment prodAptObj in objProdList)
            {
                ShoppingCartVM.Products.Add(_db.Products.Include(p => p.ProductTypes).Where(p => p.Id == prodAptObj.ProductId).FirstOrDefault());
            }

            return View(ShoppingCartVM);
        }
    }
}
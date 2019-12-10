using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCase.Data;
using TestCase.Models;

namespace TestCase.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AppointmentUserController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Appointments.ToList());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFromDb = await _db.Appointments.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointments applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(applicationUser);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFromDb = await _db.Appointments.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var productTypes = await _db.Appointments.FindAsync(id);
            _db.Appointments.Remove(productTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
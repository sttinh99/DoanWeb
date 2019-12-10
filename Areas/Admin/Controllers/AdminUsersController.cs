using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.Data;
using TestCase.Models;

namespace TestCase.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminUsersController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.UsersGuests.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersGuests user1)
        {
            if (ModelState.IsValid)
            {
                _db.Add(user1);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user1);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
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
                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var productTypes = await _db.UsersGuests.FindAsync(id);
            _db.UsersGuests.Remove(productTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
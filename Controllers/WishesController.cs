using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class WishesController : Controller
    {
        private readonly WishContext _context;
        public WishesController(WishContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Wishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            return View(wish);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Link")] Wish wish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wish);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes.FindAsync(id);
            if (wish == null)
            {
                return NotFound();
            }
            return View(wish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Link")] Wish wish)
        {
            if (id != wish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishExists(wish.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wish);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            return View(wish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wish = await _context.Wishes.FindAsync(id);
            _context.Wishes.Remove(wish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishExists(int id)
        {
            return _context.Wishes.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using baitaplonPTPMQL.Models;

namespace baitaplonPTPMQL.Controllers
{
    public class GioiTinhController : Controller
    {
        private readonly MvcMovieContext _context;

        public GioiTinhController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: GioiTinh
        public async Task<IActionResult> Index()
        {
              return _context.GioiTinh != null ? 
                          View(await _context.GioiTinh.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.GioiTinh'  is null.");
        }

        // GET: GioiTinh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GioiTinh == null)
            {
                return NotFound();
            }

            var gioiTinh = await _context.GioiTinh
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gioiTinh == null)
            {
                return NotFound();
            }

            return View(gioiTinh);
        }

        // GET: GioiTinh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GioiTinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenGioiTinh")] GioiTinh gioiTinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gioiTinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gioiTinh);
        }

        // GET: GioiTinh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GioiTinh == null)
            {
                return NotFound();
            }

            var gioiTinh = await _context.GioiTinh.FindAsync(id);
            if (gioiTinh == null)
            {
                return NotFound();
            }
            return View(gioiTinh);
        }

        // POST: GioiTinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,TenGioiTinh")] GioiTinh gioiTinh)
        {
            if (id != gioiTinh.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gioiTinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GioiTinhExists(gioiTinh.ID))
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
            return View(gioiTinh);
        }

        // GET: GioiTinh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GioiTinh == null)
            {
                return NotFound();
            }

            var gioiTinh = await _context.GioiTinh
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gioiTinh == null)
            {
                return NotFound();
            }

            return View(gioiTinh);
        }

        // POST: GioiTinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GioiTinh == null)
            {
                return Problem("Entity set 'MvcMovieContext.GioiTinh'  is null.");
            }
            var gioiTinh = await _context.GioiTinh.FindAsync(id);
            if (gioiTinh != null)
            {
                _context.GioiTinh.Remove(gioiTinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GioiTinhExists(string id)
        {
          return (_context.GioiTinh?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

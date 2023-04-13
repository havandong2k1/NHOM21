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
    public class BangGiaController : Controller
    {
        private readonly MvcMovieContext _context;

        public BangGiaController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: BangGia
        public async Task<IActionResult> Index()
        {
              return _context.BangGia != null ? 
                          View(await _context.BangGia.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.BangGia'  is null.");
        }

        // GET: BangGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BangGia == null)
            {
                return NotFound();
            }

            var bangGia = await _context.BangGia
                .FirstOrDefaultAsync(m => m.GiaID == id);
            if (bangGia == null)
            {
                return NotFound();
            }

            return View(bangGia);
        }

        // GET: BangGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BangGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiaID,GiaVe")] BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bangGia);
        }

        // GET: BangGia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BangGia == null)
            {
                return NotFound();
            }

            var bangGia = await _context.BangGia.FindAsync(id);
            if (bangGia == null)
            {
                return NotFound();
            }
            return View(bangGia);
        }

        // POST: BangGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GiaID,GiaVe")] BangGia bangGia)
        {
            if (id != bangGia.GiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangGiaExists(bangGia.GiaID))
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
            return View(bangGia);
        }

        // GET: BangGia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BangGia == null)
            {
                return NotFound();
            }

            var bangGia = await _context.BangGia
                .FirstOrDefaultAsync(m => m.GiaID == id);
            if (bangGia == null)
            {
                return NotFound();
            }

            return View(bangGia);
        }

        // POST: BangGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BangGia == null)
            {
                return Problem("Entity set 'MvcMovieContext.BangGia'  is null.");
            }
            var bangGia = await _context.BangGia.FindAsync(id);
            if (bangGia != null)
            {
                _context.BangGia.Remove(bangGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangGiaExists(string id)
        {
          return (_context.BangGia?.Any(e => e.GiaID == id)).GetValueOrDefault();
        }
        
    }
}

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
    public class TenXeController : Controller
    {
        private readonly MvcMovieContext _context;

        public TenXeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: TenXe
        public async Task<IActionResult> Index()
        {
              return _context.TenXe != null ? 
                          View(await _context.TenXe.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.TenXe'  is null.");
        }

        // GET: TenXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TenXe == null)
            {
                return NotFound();
            }

            var tenXe = await _context.TenXe
                .FirstOrDefaultAsync(m => m.XeID == id);
            if (tenXe == null)
            {
                return NotFound();
            }

            return View(tenXe);
        }

        // GET: TenXe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TenXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XeID,TenXe_BienSo")] TenXe tenXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenXe);
        }

        // GET: TenXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TenXe == null)
            {
                return NotFound();
            }

            var tenXe = await _context.TenXe.FindAsync(id);
            if (tenXe == null)
            {
                return NotFound();
            }
            return View(tenXe);
        }

        // POST: TenXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("XeID,TenXe_BienSo")] TenXe tenXe)
        {
            if (id != tenXe.XeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenXeExists(tenXe.XeID))
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
            return View(tenXe);
        }

        // GET: TenXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TenXe == null)
            {
                return NotFound();
            }

            var tenXe = await _context.TenXe
                .FirstOrDefaultAsync(m => m.XeID == id);
            if (tenXe == null)
            {
                return NotFound();
            }

            return View(tenXe);
        }

        // POST: TenXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TenXe == null)
            {
                return Problem("Entity set 'MvcMovieContext.TenXe'  is null.");
            }
            var tenXe = await _context.TenXe.FindAsync(id);
            if (tenXe != null)
            {
                _context.TenXe.Remove(tenXe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenXeExists(string id)
        {
          return (_context.TenXe?.Any(e => e.XeID == id)).GetValueOrDefault();
        }
    }
}

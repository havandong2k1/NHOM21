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
    public class XeController : Controller
    {
        private readonly MvcMovieContext _context;

        public XeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Xe
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Xe.Include(x => x.TaiXe).Include(x => x.TenXe);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Xe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Xe == null)
            {
                return NotFound();
            }

            var xe = await _context.Xe
                .Include(x => x.TaiXe)
                .Include(x => x.TenXe)
                .FirstOrDefaultAsync(m => m.MaXe == id);
            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        // GET: Xe/Create
        public IActionResult Create()
        {
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe");
            ViewData["TenCuaXe"] = new SelectList(_context.TenXe, "XeID", "XeID");
            return View();
        }

        // POST: Xe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaXe,TenCuaXe,MaTaiXe")] Xe xe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe", xe.MaTaiXe);
            ViewData["TenCuaXe"] = new SelectList(_context.TenXe, "XeID", "XeID", xe.TenCuaXe);
            return View(xe);
        }

        // GET: Xe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Xe == null)
            {
                return NotFound();
            }

            var xe = await _context.Xe.FindAsync(id);
            if (xe == null)
            {
                return NotFound();
            }
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe", xe.MaTaiXe);
            ViewData["TenCuaXe"] = new SelectList(_context.TenXe, "XeID", "XeID", xe.TenCuaXe);
            return View(xe);
        }

        // POST: Xe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaXe,TenCuaXe,MaTaiXe")] Xe xe)
        {
            if (id != xe.MaXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XeExists(xe.MaXe))
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
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe", xe.MaTaiXe);
            ViewData["TenCuaXe"] = new SelectList(_context.TenXe, "XeID", "XeID", xe.TenCuaXe);
            return View(xe);
        }

        // GET: Xe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Xe == null)
            {
                return NotFound();
            }

            var xe = await _context.Xe
                .Include(x => x.TaiXe)
                .Include(x => x.TenXe)
                .FirstOrDefaultAsync(m => m.MaXe == id);
            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        // POST: Xe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Xe == null)
            {
                return Problem("Entity set 'MvcMovieContext.Xe'  is null.");
            }
            var xe = await _context.Xe.FindAsync(id);
            if (xe != null)
            {
                _context.Xe.Remove(xe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XeExists(string id)
        {
          return (_context.Xe?.Any(e => e.MaXe == id)).GetValueOrDefault();
        }
    }
}

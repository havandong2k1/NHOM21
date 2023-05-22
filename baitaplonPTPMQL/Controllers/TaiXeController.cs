using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using baitaplonPTPMQL.Models;
using baitaplonPTPMQL.Models.Process;

namespace baitaplonPTPMQL.Controllers
{
    public class TaiXeController : Controller
    {
        private readonly MvcMovieContext _context;
         private StringProcess strPro = new StringProcess();

        public TaiXeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: TaiXe
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.TaiXe.Include(t => t.GioiTinh);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: TaiXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TaiXe == null)
            {
                return NotFound();
            }

            var taiXe = await _context.TaiXe
                .Include(t => t.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaTaiXe == id);
            if (taiXe == null)
            {
                return NotFound();
            }

            return View(taiXe);
        }

        // GET: TaiXe/Create
        public IActionResult Create()
        {
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "TenGioiTinh");
             var newnhacungcap = "TX001";
            var countnhacungcap = _context.NhanVien.Count();
            if (countnhacungcap > 0)
            {
                var MaTX = _context.TaiXe.OrderByDescending(m => m.MaTaiXe).First().MaTaiXe;
                newnhacungcap = strPro.AutoGenerateCode(MaTX);
            }
            ViewBag.newID = newnhacungcap;
            return View();
        }

        // POST: TaiXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTaiXe,TenTaiXe,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] TaiXe taiXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "TenGioiTinh", taiXe.TenGioiTinh);
            return View(taiXe);
        }

        // GET: TaiXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TaiXe == null)
            {
                return NotFound();
            }

            var taiXe = await _context.TaiXe.FindAsync(id);
            if (taiXe == null)
            {
                return NotFound();
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "TenGioiTinh", taiXe.TenGioiTinh);
            return View(taiXe);
        }

        // POST: TaiXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTaiXe,TenTaiXe,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] TaiXe taiXe)
        {
            if (id != taiXe.MaTaiXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiXeExists(taiXe.MaTaiXe))
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
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "ID", taiXe.TenGioiTinh);
            return View(taiXe);
        }

        // GET: TaiXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TaiXe == null)
            {
                return NotFound();
            }

            var taiXe = await _context.TaiXe
                .Include(t => t.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaTaiXe == id);
            if (taiXe == null)
            {
                return NotFound();
            }

            return View(taiXe);
        }

        // POST: TaiXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TaiXe == null)
            {
                return Problem("Entity set 'MvcMovieContext.TaiXe'  is null.");
            }
            var taiXe = await _context.TaiXe.FindAsync(id);
            if (taiXe != null)
            {
                _context.TaiXe.Remove(taiXe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiXeExists(string id)
        {
          return (_context.TaiXe?.Any(e => e.MaTaiXe == id)).GetValueOrDefault();
        }
    }
}

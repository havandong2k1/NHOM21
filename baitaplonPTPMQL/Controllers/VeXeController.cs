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
    public class VeXeController : Controller
    {
        private readonly MvcMovieContext _context;
         private StringProcess strPro = new StringProcess();

        public VeXeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: VeXe
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.VeXe.Include(v => v.KhachHang).Include(v => v.NhanVien).Include(v => v.TenXe);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: VeXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VeXe == null)
            {
                return NotFound();
            }

            var veXe = await _context.VeXe
                .Include(v => v.KhachHang)
                .Include(v => v.NhanVien)
                .Include(v => v.TenXe)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (veXe == null)
            {
                return NotFound();
            }

            return View(veXe);
        }

        // GET: VeXe/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "MaKhachHang");
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "MaNhanVien");
            ViewData["TenXe_BienSo"] = new SelectList(_context.TenXe, "XeID", "TenXe_BienSo");
             var newnhacungcap = "VX001";
            var countnhacungcap = _context.KhachHang.Count();
            if (countnhacungcap > 0)
            {
                var MaVX = _context.VeXe.OrderByDescending(m => m.MaVe).First().MaVe;
                newnhacungcap = strPro.AutoGenerateCode(MaVX);
            }
            ViewBag.newID = newnhacungcap;
            return View();
        }

        // POST: VeXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaVe,TenVe,TenXe_BienSo,MaNhanVien,MaKhachHang")] VeXe veXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "MaKhachHang", veXe.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "MaNhanVien", veXe.MaNhanVien);
            ViewData["TenXe_BienSo"] = new SelectList(_context.TenXe, "XeID", "TenXe_BienSo", veXe.TenXe_BienSo);
            return View(veXe);
        }

        // GET: VeXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VeXe == null)
            {
                return NotFound();
            }

            var veXe = await _context.VeXe.FindAsync(id);
            if (veXe == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "MaKhachHang", veXe.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "MaNhanVien", veXe.MaNhanVien);
            ViewData["TenXe_BienSo"] = new SelectList(_context.TenXe, "XeID", "XeID", veXe.TenXe_BienSo);
            return View(veXe);
        }

        // POST: VeXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaVe,TenVe,TenXe_BienSo,MaNhanVien,MaKhachHang")] VeXe veXe)
        {
            if (id != veXe.MaVe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeXeExists(veXe.MaVe))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "MaKhachHang", veXe.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "MaNhanVien", veXe.MaNhanVien);
            ViewData["TenXe_BienSo"] = new SelectList(_context.TenXe, "XeID", "XeID", veXe.TenXe_BienSo);
            return View(veXe);
        }

        // GET: VeXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VeXe == null)
            {
                return NotFound();
            }

            var veXe = await _context.VeXe
                .Include(v => v.KhachHang)
                .Include(v => v.NhanVien)
                .Include(v => v.TenXe)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (veXe == null)
            {
                return NotFound();
            }

            return View(veXe);
        }

        // POST: VeXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VeXe == null)
            {
                return Problem("Entity set 'MvcMovieContext.VeXe'  is null.");
            }
            var veXe = await _context.VeXe.FindAsync(id);
            if (veXe != null)
            {
                _context.VeXe.Remove(veXe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeXeExists(string id)
        {
          return (_context.VeXe?.Any(e => e.MaVe == id)).GetValueOrDefault();
        }
    }
}

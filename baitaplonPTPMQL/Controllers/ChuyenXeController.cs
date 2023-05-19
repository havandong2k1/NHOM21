using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using baitaplonPTPMQL.Models;


namespace baitaplonPTPMQL.Controllers
{
    public class ChuyenXeController : Controller
    {
        private readonly MvcMovieContext _context;

        public ChuyenXeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: ChuyenXe
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.ChuyenXe.Include(c => c.BangGia).Include(c => c.TaiXe);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: ChuyenXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChuyenXe == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXe
                .Include(c => c.BangGia)
                .Include(c => c.TaiXe)
                .FirstOrDefaultAsync(m => m.MaChuyenXe == id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            return View(chuyenXe);
        }

        // GET: ChuyenXe/Create
        public IActionResult Create()
        {
            ViewData["GiaID"] = new SelectList(_context.BangGia, "GiaID", "GiaVe");
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXe>(), "MaTaiXe", "MaTaiXe");
            return View();
        }

        // POST: ChuyenXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuyenXe,TenChuyenXe,NgayDi,DiemDi,DiemDen,MaTaiXe,GiaID")] ChuyenXe chuyenXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuyenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiaID"] = new SelectList(_context.BangGia, "GiaID", "GiaVe", chuyenXe.GiaID);
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXe>(), "MaTaiXe", "MaTaiXe", chuyenXe.MaTaiXe);
            return View(chuyenXe);
        }

        // GET: ChuyenXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChuyenXe == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXe.FindAsync(id);
            if (chuyenXe == null)
            {
                return NotFound();
            }
            ViewData["GiaID"] = new SelectList(_context.BangGia, "GiaID", "GiaID", chuyenXe.GiaID);
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXe>(), "MaTaiXe", "MaTaiXe", chuyenXe.MaTaiXe);
            return View(chuyenXe);
        }

        // POST: ChuyenXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChuyenXe,TenChuyenXe,NgayDi,DiemDi,DiemDen,MaTaiXe,GiaID")] ChuyenXe chuyenXe)
        {
            if (id != chuyenXe.MaChuyenXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyenXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuyenXeExists(chuyenXe.MaChuyenXe))
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
            ViewData["GiaID"] = new SelectList(_context.BangGia, "GiaID", "GiaID", chuyenXe.GiaID);
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXe>(), "MaTaiXe", "MaTaiXe", chuyenXe.MaTaiXe);
            return View(chuyenXe);
        }

        // GET: ChuyenXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChuyenXe == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXe
                .Include(c => c.BangGia)
                .Include(c => c.TaiXe)
                .FirstOrDefaultAsync(m => m.MaChuyenXe == id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            return View(chuyenXe);
        }

        // POST: ChuyenXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChuyenXe == null)
            {
                return Problem("Entity set 'MvcMovieContext.ChuyenXe'  is null.");
            }
            var chuyenXe = await _context.ChuyenXe.FindAsync(id);
            if (chuyenXe != null)
            {
                _context.ChuyenXe.Remove(chuyenXe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuyenXeExists(string id)
        {
          return (_context.ChuyenXe?.Any(e => e.MaChuyenXe == id)).GetValueOrDefault();
        }
       
    }
}



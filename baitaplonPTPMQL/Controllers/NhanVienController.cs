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

    public class NhanVienController : Controller
    {
        private readonly MvcMovieContext _context;
         private StringProcess strPro = new StringProcess();

        public NhanVienController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.NhanVien.Include(n => n.GioiTinh);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "TenGioiTinh");
            var newnhacungcap = "NV01";
            var countnhacungcap = _context.NhanVien.Count();
            if (countnhacungcap > 0)
            {
                var Manv = _context.NhanVien.OrderByDescending(m => m.MaNhanVien).First().MaNhanVien;
                newnhacungcap = strPro.AutoGenerateCode(Manv);
            }
            ViewBag.newID = newnhacungcap;

            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,TenNhanVien,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "TenGioiTinh", nhanVien.TenGioiTinh);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "TenGioiTinh", nhanVien.TenGioiTinh);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhanVien,TenNhanVien,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNhanVien))
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
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinh, "ID", "ID", nhanVien.TenGioiTinh);
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhanVien == null)
            {
                return Problem("Entity set 'MvcMovieContext.NhanVien'  is null.");
            }
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
          return (_context.NhanVien?.Any(e => e.MaNhanVien == id)).GetValueOrDefault();
        }
     private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //dùng vòng lặp for để đọc dữ liệu dạng hd
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var nv = new NhanVien();
                            //set values for attribiutes
                            nv.MaNhanVien = dt.Rows[i][0].ToString();
                            nv.TenNhanVien = dt.Rows[i][1].ToString();
                            nv.Ngaysinh = Convert.ToDateTime(dt.Rows[i][2].ToString());
                            nv.TenGioiTinh = dt.Rows[i][3].ToString();
                            nv.Diachi = dt.Rows[i][4].ToString();
                            nv.CMND = dt.Rows[i][5].ToString();
                            nv.SoDienThoai = dt.Rows[i][6].ToString();
                            //add oject to context
                            _context.NhanVien.Add(nv);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        
    }
 }  
}


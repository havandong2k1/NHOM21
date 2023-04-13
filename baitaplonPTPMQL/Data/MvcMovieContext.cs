using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using baitaplonPTPMQL.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<baitaplonPTPMQL.Models.BangGia> BangGia { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.ChuyenXe> ChuyenXe { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.GioiTinh> GioiTinh { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.TaiXe> TaiXe { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.TenXe> TenXe { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.VeXe> VeXe { get; set; } = default!;

        public DbSet<baitaplonPTPMQL.Models.Xe> Xe { get; set; } = default!;
    }
}

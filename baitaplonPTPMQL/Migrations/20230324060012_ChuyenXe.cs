using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baitaplonPTPMQL.Migrations
{
    /// <inheritdoc />
    public partial class ChuyenXe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangGia",
                columns: table => new
                {
                    GiaID = table.Column<string>(type: "TEXT", nullable: false),
                    GiaVe = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGia", x => x.GiaID);
                });

            migrationBuilder.CreateTable(
                name: "GioiTinh",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioiTinh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TenXe",
                columns: table => new
                {
                    XeID = table.Column<string>(type: "TEXT", nullable: false),
                    TenXeBienSo = table.Column<string>(name: "TenXe_BienSo", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenXe", x => x.XeID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    TenKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHang_GioiTinh_TenGioiTinh",
                        column: x => x.TenGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    TenNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_GioiTinh_TenGioiTinh",
                        column: x => x.TenGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TaiXe",
                columns: table => new
                {
                    MaTaiXe = table.Column<string>(type: "TEXT", nullable: false),
                    TenTaiXe = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    CMND = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiXe", x => x.MaTaiXe);
                    table.ForeignKey(
                        name: "FK_TaiXe_GioiTinh_TenGioiTinh",
                        column: x => x.TenGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "VeXe",
                columns: table => new
                {
                    MaVe = table.Column<string>(type: "TEXT", nullable: false),
                    TenVe = table.Column<string>(type: "TEXT", nullable: true),
                    TenXeBienSo = table.Column<string>(name: "TenXe_BienSo", type: "TEXT", nullable: true),
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: true),
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeXe", x => x.MaVe);
                    table.ForeignKey(
                        name: "FK_VeXe_KhachHang_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang");
                    table.ForeignKey(
                        name: "FK_VeXe_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                    table.ForeignKey(
                        name: "FK_VeXe_TenXe_TenXe_BienSo",
                        column: x => x.TenXeBienSo,
                        principalTable: "TenXe",
                        principalColumn: "XeID");
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXe",
                columns: table => new
                {
                    MaChuyenXe = table.Column<string>(type: "TEXT", nullable: false),
                    TenChuyenXe = table.Column<string>(type: "TEXT", nullable: true),
                    NgayDi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiemDi = table.Column<string>(type: "TEXT", nullable: true),
                    DiemDen = table.Column<string>(type: "TEXT", nullable: true),
                    MaTaiXe = table.Column<string>(type: "TEXT", nullable: false),
                    GiaID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXe", x => x.MaChuyenXe);
                    table.ForeignKey(
                        name: "FK_ChuyenXe_BangGia_GiaID",
                        column: x => x.GiaID,
                        principalTable: "BangGia",
                        principalColumn: "GiaID");
                    table.ForeignKey(
                        name: "FK_ChuyenXe_TaiXe_MaTaiXe",
                        column: x => x.MaTaiXe,
                        principalTable: "TaiXe",
                        principalColumn: "MaTaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xe",
                columns: table => new
                {
                    MaXe = table.Column<string>(type: "TEXT", nullable: false),
                    TenCuaXe = table.Column<string>(type: "TEXT", nullable: true),
                    MaTaiXe = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xe", x => x.MaXe);
                    table.ForeignKey(
                        name: "FK_Xe_TaiXe_MaTaiXe",
                        column: x => x.MaTaiXe,
                        principalTable: "TaiXe",
                        principalColumn: "MaTaiXe");
                    table.ForeignKey(
                        name: "FK_Xe_TenXe_TenCuaXe",
                        column: x => x.TenCuaXe,
                        principalTable: "TenXe",
                        principalColumn: "XeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXe_GiaID",
                table: "ChuyenXe",
                column: "GiaID");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXe_MaTaiXe",
                table: "ChuyenXe",
                column: "MaTaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_TenGioiTinh",
                table: "KhachHang",
                column: "TenGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TenGioiTinh",
                table: "NhanVien",
                column: "TenGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_TaiXe_TenGioiTinh",
                table: "TaiXe",
                column: "TenGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_MaKhachHang",
                table: "VeXe",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_MaNhanVien",
                table: "VeXe",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_VeXe_TenXe_BienSo",
                table: "VeXe",
                column: "TenXe_BienSo");

            migrationBuilder.CreateIndex(
                name: "IX_Xe_MaTaiXe",
                table: "Xe",
                column: "MaTaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_Xe_TenCuaXe",
                table: "Xe",
                column: "TenCuaXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuyenXe");

            migrationBuilder.DropTable(
                name: "VeXe");

            migrationBuilder.DropTable(
                name: "Xe");

            migrationBuilder.DropTable(
                name: "BangGia");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "TaiXe");

            migrationBuilder.DropTable(
                name: "TenXe");

            migrationBuilder.DropTable(
                name: "GioiTinh");
        }
    }
}

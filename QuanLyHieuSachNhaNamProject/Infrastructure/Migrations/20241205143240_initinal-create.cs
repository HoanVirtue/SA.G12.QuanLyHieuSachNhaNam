using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initinalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblNhanvien",
                columns: table => new
                {
                    sMaNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sTenNV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dNgaysinh = table.Column<DateOnly>(type: "date", nullable: true),
                    bGioitinh = table.Column<bool>(type: "bit", nullable: false),
                    sDiachi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dNgayvaolam = table.Column<DateOnly>(type: "date", nullable: false),
                    sSDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    fLuong = table.Column<double>(type: "float", nullable: false),
                    bVaitro = table.Column<bool>(type: "bit", nullable: false),
                    bTrangthai = table.Column<bool>(type: "bit", nullable: false),
                    sCCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblNhanv__328E1C0FB7CCACC6", x => x.sMaNV);
                });

            migrationBuilder.CreateTable(
                name: "tblSach",
                columns: table => new
                {
                    sMasach = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sTensach = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sTenTG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    iDongia = table.Column<double>(type: "float", nullable: false),
                    iSoluong = table.Column<int>(type: "int", nullable: false),
                    sNXB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sTheloai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblSach__EA6DC7103193D482", x => x.sMasach);
                });

            migrationBuilder.CreateTable(
                name: "tblHoaDon",
                columns: table => new
                {
                    sMaHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sMaNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dNgaylap = table.Column<DateOnly>(type: "date", nullable: false),
                    fTongHD = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblHoaDo__328E4D551579AD7F", x => x.sMaHD);
                    table.ForeignKey(
                        name: "FK_tblHoaDon_tblNhanvien",
                        column: x => x.sMaNV,
                        principalTable: "tblNhanvien",
                        principalColumn: "sMaNV");
                });

            migrationBuilder.CreateTable(
                name: "tblNhap",
                columns: table => new
                {
                    MaPN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sMaNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dNgaylap = table.Column<DateOnly>(type: "date", nullable: false),
                    bLoai = table.Column<bool>(type: "bit", nullable: false),
                    fTongGT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblNhap__2725E7F0A292050E", x => x.MaPN);
                    table.ForeignKey(
                        name: "FK_tblNhap_tblNhanvien",
                        column: x => x.sMaNV,
                        principalTable: "tblNhanvien",
                        principalColumn: "sMaNV");
                });

            migrationBuilder.CreateTable(
                name: "tblTaikhoan",
                columns: table => new
                {
                    sMaNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sMatkhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblTaikh__328E1C0FCE34D502", x => x.sMaNV);
                    table.ForeignKey(
                        name: "FK_tblTaikhoan_tblNhanvien",
                        column: x => x.sMaNV,
                        principalTable: "tblNhanvien",
                        principalColumn: "sMaNV");
                });

            migrationBuilder.CreateTable(
                name: "tblChiTietHoaDon",
                columns: table => new
                {
                    sMaHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sMaSach = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    iSoluong = table.Column<int>(type: "int", nullable: false),
                    fDongia = table.Column<double>(type: "float", nullable: false),
                    fThanhtien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChiTietHoaDon", x => new { x.sMaHD, x.sMaSach });
                    table.ForeignKey(
                        name: "FK_tblChiTietHoaDon_tblHoaDon",
                        column: x => x.sMaHD,
                        principalTable: "tblHoaDon",
                        principalColumn: "sMaHD");
                    table.ForeignKey(
                        name: "FK_tblChiTietHoaDon_tblSach",
                        column: x => x.sMaSach,
                        principalTable: "tblSach",
                        principalColumn: "sMasach");
                });

            migrationBuilder.CreateTable(
                name: "tblChiTietNhap",
                columns: table => new
                {
                    MaPN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    sMasach = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    iSoluong = table.Column<int>(type: "int", nullable: false),
                    fDongia = table.Column<double>(type: "float", nullable: false),
                    fThanhtien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChiTietNhap", x => new { x.MaPN, x.sMasach });
                    table.ForeignKey(
                        name: "FK_tblChiTietNhap_tblNhap",
                        column: x => x.MaPN,
                        principalTable: "tblNhap",
                        principalColumn: "MaPN");
                    table.ForeignKey(
                        name: "FK_tblChiTietNhap_tblSach",
                        column: x => x.sMasach,
                        principalTable: "tblSach",
                        principalColumn: "sMasach");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblChiTietHoaDon_sMaSach",
                table: "tblChiTietHoaDon",
                column: "sMaSach");

            migrationBuilder.CreateIndex(
                name: "IX_tblChiTietNhap_sMasach",
                table: "tblChiTietNhap",
                column: "sMasach");

            migrationBuilder.CreateIndex(
                name: "IX_tblHoaDon_sMaNV",
                table: "tblHoaDon",
                column: "sMaNV");

            migrationBuilder.CreateIndex(
                name: "UQ__tblNhanv__31AF424FA59EB373",
                table: "tblNhanvien",
                column: "sCCCD",
                unique: true,
                filter: "[sCCCD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblNhap_sMaNV",
                table: "tblNhap",
                column: "sMaNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "tblChiTietNhap");

            migrationBuilder.DropTable(
                name: "tblTaikhoan");

            migrationBuilder.DropTable(
                name: "tblHoaDon");

            migrationBuilder.DropTable(
                name: "tblNhap");

            migrationBuilder.DropTable(
                name: "tblSach");

            migrationBuilder.DropTable(
                name: "tblNhanvien");
        }
    }
}

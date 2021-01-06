using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.WebApp.Migrations
{
    public partial class eShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSach",
                columns: table => new
                {
                    MaLoai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenLoai = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSach", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoTen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDH = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaKH = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: true),
                    NgayDat = table.Column<DateTime>(nullable: false),
                    NoiGiao = table.Column<string>(nullable: true),
                    TinhTrang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDH);
                    table.ForeignKey(
                        name: "FK_DonHang_TaiKhoan_ID",
                        column: x => x.ID,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CTDH",
                columns: table => new
                {
                    SoCT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaDH = table.Column<int>(nullable: false),
                    MaSach = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTDH", x => x.SoCT);
                    table.ForeignKey(
                        name: "FK_CTDH_DonHang_MaDH",
                        column: x => x.MaDH,
                        principalTable: "DonHang",
                        principalColumn: "MaDH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    MaSach = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenSach = table.Column<string>(nullable: true),
                    TacGia = table.Column<string>(nullable: true),
                    MaLoai = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    Hinh = table.Column<string>(nullable: true),
                    Gia = table.Column<double>(nullable: false),
                    GioHangMaGH = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.MaSach);
                    table.ForeignKey(
                        name: "FK_Sach_LoaiSach_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiSach",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    MaGH = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaKH = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: true),
                    MaSach = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.MaGH);
                    table.ForeignKey(
                        name: "FK_GioHang_TaiKhoan_ID",
                        column: x => x.ID,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GioHang_Sach_MaSach",
                        column: x => x.MaSach,
                        principalTable: "Sach",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTDH_MaDH",
                table: "CTDH",
                column: "MaDH");

            migrationBuilder.CreateIndex(
                name: "IX_CTDH_MaSach",
                table: "CTDH",
                column: "MaSach");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_ID",
                table: "DonHang",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_ID",
                table: "GioHang",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_MaSach",
                table: "GioHang",
                column: "MaSach");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_GioHangMaGH",
                table: "Sach",
                column: "GioHangMaGH");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_MaLoai",
                table: "Sach",
                column: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_CTDH_Sach_MaSach",
                table: "CTDH",
                column: "MaSach",
                principalTable: "Sach",
                principalColumn: "MaSach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_GioHang_GioHangMaGH",
                table: "Sach",
                column: "GioHangMaGH",
                principalTable: "GioHang",
                principalColumn: "MaGH",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_Sach_MaSach",
                table: "GioHang");

            migrationBuilder.DropTable(
                name: "CTDH");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "LoaiSach");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHOA",
                columns: table => new
                {
                    KHOA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SO_HIEU_KHOA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEN_KHOA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHOA", x => x.KHOA_ID);
                });

            migrationBuilder.CreateTable(
                name: "SINH_VIEN",
                columns: table => new
                {
                    SINH_VIEN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_SINH_VIEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TEN_SINH_VIEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NGAY_SINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GIOI_TINH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SINH_VIEN", x => x.SINH_VIEN_ID);
                    table.ForeignKey(
                        name: "FK_SINH_VIEN_KHOA_KhId",
                        column: x => x.KhId,
                        principalTable: "KHOA",
                        principalColumn: "KHOA_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SINH_VIEN_KhId",
                table: "SINH_VIEN",
                column: "KhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SINH_VIEN");

            migrationBuilder.DropTable(
                name: "KHOA");
        }
    }
}

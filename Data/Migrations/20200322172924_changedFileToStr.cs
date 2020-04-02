using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoContratos.Data.Migrations
{
    public partial class changedFileToStr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "File",
                table: "Contract",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "Contract",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

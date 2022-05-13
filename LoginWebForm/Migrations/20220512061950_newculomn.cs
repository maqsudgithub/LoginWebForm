using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginWebForm.Migrations
{
    public partial class newculomn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepID",
                table: "tbl_Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DesID",
                table: "tbl_Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepID",
                table: "tbl_Employee");

            migrationBuilder.DropColumn(
                name: "DesID",
                table: "tbl_Employee");
        }
    }
}

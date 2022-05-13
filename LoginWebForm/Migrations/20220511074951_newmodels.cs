using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginWebForm.Migrations
{
    public partial class newmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendence",
                table: "Attendence");

            migrationBuilder.RenameTable(
                name: "Attendence",
                newName: "tbl_Attendence");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Attendence",
                table: "tbl_Attendence",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "tbl_Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Designation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Designation", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Department");

            migrationBuilder.DropTable(
                name: "tbl_Designation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Attendence",
                table: "tbl_Attendence");

            migrationBuilder.RenameTable(
                name: "tbl_Attendence",
                newName: "Attendence");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendence",
                table: "Attendence",
                column: "ID");
        }
    }
}

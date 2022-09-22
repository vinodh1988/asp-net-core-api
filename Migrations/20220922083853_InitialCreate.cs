using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    dno = table.Column<int>(type: "NUMBER(5)", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_dno", x => x.dno);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    sno = table.Column<int>(type: "NUMBER(5)", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_sno", x => x.sno);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    eno = table.Column<int>(type: "NUMBER(5)", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    dno = table.Column<int>(type: "NUMBER(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_eno", x => x.eno);
                    table.ForeignKey(
                        name: "FK_employee_department_dno",
                        column: x => x.dno,
                        principalTable: "department",
                        principalColumn: "dno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_dno",
                table: "employee",
                column: "dno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}

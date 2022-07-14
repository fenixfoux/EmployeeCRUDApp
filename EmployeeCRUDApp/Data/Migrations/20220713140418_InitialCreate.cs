using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeCRUDApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FIRSTNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LASTNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MOBILENUMBER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ADDRESSLINE1 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ADDRESSLINE2 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CITY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES");
        }
    }
}

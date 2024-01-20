using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mgmt1.Migrations
{
    /// <inheritdoc />
    public partial class guest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
     name: "Guests",
     columns: table => new
     {
         Id = table.Column<int>(type: "int", nullable: false)
             .Annotation("SqlServer:Identity", "1, 1"),
         FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
         LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
         PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
         Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
         CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
         CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
     },
     constraints: table =>
     {
         table.PrimaryKey("PK_Guests", x => x.Id);
     });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}

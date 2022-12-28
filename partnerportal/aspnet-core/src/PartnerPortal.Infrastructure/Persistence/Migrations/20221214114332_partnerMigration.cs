using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class partnerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectManagers",
                columns: table => new
                {
                    ProjectManagerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMEmailID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagers", x => x.ProjectManagerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectManagers");
        }
    }
}

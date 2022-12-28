using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class requestionSkillPartner1Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "TodoLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "TodoLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "Countrys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Countrys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerID);
                });

            migrationBuilder.CreateTable(
                name: "Requisition",
                columns: table => new
                {
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PotentialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complexity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCountreyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitionStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisition", x => x.RequisitionID);
                    table.ForeignKey(
                        name: "FK_Requisition_Countrys_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countrys",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisition_Currencys_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencys",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisition_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionFile",
                columns: table => new
                {
                    RequisitionFileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionFile", x => x.RequisitionFileID);
                    table.ForeignKey(
                        name: "FK_RequisitionFile_Requisition_RequisitionID",
                        column: x => x.RequisitionID,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionJD",
                columns: table => new
                {
                    RequisitionJDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DurationUnits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftTimings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfResources = table.Column<int>(type: "int", nullable: false),
                    OpenPositions = table.Column<int>(type: "int", nullable: false),
                    KeyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinExperience = table.Column<int>(type: "int", nullable: false),
                    MaxExperience = table.Column<int>(type: "int", nullable: false),
                    JDFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionJD", x => x.RequisitionJDID);
                    table.ForeignKey(
                        name: "FK_RequisitionJD_Requisition_RequisitionID",
                        column: x => x.RequisitionID,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionPartner",
                columns: table => new
                {
                    RequsitionPartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requestionIdRequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionPartner", x => x.RequsitionPartnerID);
                    table.ForeignKey(
                        name: "FK_RequisitionPartner_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionPartner_Requisition_requestionIdRequisitionID",
                        column: x => x.requestionIdRequisitionID,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionSkills",
                columns: table => new
                {
                    RequisitionSkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mandatory = table.Column<byte>(type: "tinyint", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionSkills", x => x.RequisitionSkillID);
                    table.ForeignKey(
                        name: "FK_RequisitionSkills_Requisition_RequisitionID",
                        column: x => x.RequisitionID,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CountryID",
                table: "Requisition",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CurrencyID",
                table: "Requisition",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_DepartmentID",
                table: "Requisition",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionFile_RequisitionID",
                table: "RequisitionFile",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionJD_RequisitionID",
                table: "RequisitionJD",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionPartner_PartnerId",
                table: "RequisitionPartner",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionPartner_requestionIdRequisitionID",
                table: "RequisitionPartner",
                column: "requestionIdRequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionSkills_RequisitionID",
                table: "RequisitionSkills",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionSkills_SkillID",
                table: "RequisitionSkills",
                column: "SkillID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisitionFile");

            migrationBuilder.DropTable(
                name: "RequisitionJD");

            migrationBuilder.DropTable(
                name: "RequisitionPartner");

            migrationBuilder.DropTable(
                name: "RequisitionSkills");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Requisition");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Countrys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Countrys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}

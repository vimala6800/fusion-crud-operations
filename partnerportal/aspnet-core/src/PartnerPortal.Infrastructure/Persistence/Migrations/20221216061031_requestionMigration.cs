using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class requestionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_Countrys_CountryID",
                table: "Requisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_Currencys_CurrencyID",
                table: "Requisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_Departments_DepartmentID",
                table: "Requisition");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionFiles_Requisition_RequisitionID",
                table: "RequisitionFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionJDs_Requisition_RequisitionID",
                table: "RequisitionJDs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartners_Requisition_RequestionID",
                table: "RequisitionPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionSkills_Requisition_RequisitionID",
                table: "RequisitionSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requisition",
                table: "Requisition");

            migrationBuilder.DropIndex(
                name: "IX_Requisition_CountryID",
                table: "Requisition");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Requisition");

            migrationBuilder.RenameTable(
                name: "Requisition",
                newName: "Requisitions");

            migrationBuilder.RenameIndex(
                name: "IX_Requisition_DepartmentID",
                table: "Requisitions",
                newName: "IX_Requisitions_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Requisition_CurrencyID",
                table: "Requisitions",
                newName: "IX_Requisitions_CurrencyID");

            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                table: "Requisitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requisitions",
                table: "Requisitions",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_ClientCountreyID",
                table: "Requisitions",
                column: "ClientCountreyID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionFiles_Requisitions_RequisitionID",
                table: "RequisitionFiles",
                column: "RequisitionID",
                principalTable: "Requisitions",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionJDs_Requisitions_RequisitionID",
                table: "RequisitionJDs",
                column: "RequisitionID",
                principalTable: "Requisitions",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartners_Requisitions_RequestionID",
                table: "RequisitionPartners",
                column: "RequestionID",
                principalTable: "Requisitions",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Countrys_ClientCountreyID",
                table: "Requisitions",
                column: "ClientCountreyID",
                principalTable: "Countrys",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Currencys_CurrencyID",
                table: "Requisitions",
                column: "CurrencyID",
                principalTable: "Currencys",
                principalColumn: "CurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Departments_DepartmentID",
                table: "Requisitions",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionSkills_Requisitions_RequisitionID",
                table: "RequisitionSkills",
                column: "RequisitionID",
                principalTable: "Requisitions",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionFiles_Requisitions_RequisitionID",
                table: "RequisitionFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionJDs_Requisitions_RequisitionID",
                table: "RequisitionJDs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartners_Requisitions_RequestionID",
                table: "RequisitionPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Countrys_ClientCountreyID",
                table: "Requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Currencys_CurrencyID",
                table: "Requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Departments_DepartmentID",
                table: "Requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionSkills_Requisitions_RequisitionID",
                table: "RequisitionSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requisitions",
                table: "Requisitions");

            migrationBuilder.DropIndex(
                name: "IX_Requisitions_ClientCountreyID",
                table: "Requisitions");

            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                table: "Requisitions");

            migrationBuilder.RenameTable(
                name: "Requisitions",
                newName: "Requisition");

            migrationBuilder.RenameIndex(
                name: "IX_Requisitions_DepartmentID",
                table: "Requisition",
                newName: "IX_Requisition_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Requisitions_CurrencyID",
                table: "Requisition",
                newName: "IX_Requisition_CurrencyID");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryID",
                table: "Requisition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requisition",
                table: "Requisition",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CountryID",
                table: "Requisition",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_Countrys_CountryID",
                table: "Requisition",
                column: "CountryID",
                principalTable: "Countrys",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_Currencys_CurrencyID",
                table: "Requisition",
                column: "CurrencyID",
                principalTable: "Currencys",
                principalColumn: "CurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_Departments_DepartmentID",
                table: "Requisition",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionFiles_Requisition_RequisitionID",
                table: "RequisitionFiles",
                column: "RequisitionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionJDs_Requisition_RequisitionID",
                table: "RequisitionJDs",
                column: "RequisitionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartners_Requisition_RequestionID",
                table: "RequisitionPartners",
                column: "RequestionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionSkills_Requisition_RequisitionID",
                table: "RequisitionSkills",
                column: "RequisitionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

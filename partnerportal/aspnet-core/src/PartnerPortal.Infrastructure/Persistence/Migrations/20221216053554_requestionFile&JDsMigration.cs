using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class requestionFileJDsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionFile_Requisition_RequisitionID",
                table: "RequisitionFile");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionJD_Requisition_RequisitionID",
                table: "RequisitionJD");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartner_Requisition_requestionIdRequisitionID",
                table: "RequisitionPartner");

            migrationBuilder.DropIndex(
                name: "IX_RequisitionPartner_requestionIdRequisitionID",
                table: "RequisitionPartner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisitionJD",
                table: "RequisitionJD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisitionFile",
                table: "RequisitionFile");

            migrationBuilder.DropColumn(
                name: "requestionIdRequisitionID",
                table: "RequisitionPartner");

            migrationBuilder.RenameTable(
                name: "RequisitionJD",
                newName: "RequisitionJDs");

            migrationBuilder.RenameTable(
                name: "RequisitionFile",
                newName: "RequisitionFiles");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionJD_RequisitionID",
                table: "RequisitionJDs",
                newName: "IX_RequisitionJDs_RequisitionID");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionFile_RequisitionID",
                table: "RequisitionFiles",
                newName: "IX_RequisitionFiles_RequisitionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisitionJDs",
                table: "RequisitionJDs",
                column: "RequisitionJDID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisitionFiles",
                table: "RequisitionFiles",
                column: "RequisitionFileID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionPartner_RequestionID",
                table: "RequisitionPartner",
                column: "RequestionID");

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
                name: "FK_RequisitionPartner_Requisition_RequestionID",
                table: "RequisitionPartner",
                column: "RequestionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionFiles_Requisition_RequisitionID",
                table: "RequisitionFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionJDs_Requisition_RequisitionID",
                table: "RequisitionJDs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartner_Requisition_RequestionID",
                table: "RequisitionPartner");

            migrationBuilder.DropIndex(
                name: "IX_RequisitionPartner_RequestionID",
                table: "RequisitionPartner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisitionJDs",
                table: "RequisitionJDs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisitionFiles",
                table: "RequisitionFiles");

            migrationBuilder.RenameTable(
                name: "RequisitionJDs",
                newName: "RequisitionJD");

            migrationBuilder.RenameTable(
                name: "RequisitionFiles",
                newName: "RequisitionFile");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionJDs_RequisitionID",
                table: "RequisitionJD",
                newName: "IX_RequisitionJD_RequisitionID");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionFiles_RequisitionID",
                table: "RequisitionFile",
                newName: "IX_RequisitionFile_RequisitionID");

            migrationBuilder.AddColumn<Guid>(
                name: "requestionIdRequisitionID",
                table: "RequisitionPartner",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisitionJD",
                table: "RequisitionJD",
                column: "RequisitionJDID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisitionFile",
                table: "RequisitionFile",
                column: "RequisitionFileID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionPartner_requestionIdRequisitionID",
                table: "RequisitionPartner",
                column: "requestionIdRequisitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionFile_Requisition_RequisitionID",
                table: "RequisitionFile",
                column: "RequisitionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionJD_Requisition_RequisitionID",
                table: "RequisitionJD",
                column: "RequisitionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartner_Requisition_requestionIdRequisitionID",
                table: "RequisitionPartner",
                column: "requestionIdRequisitionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

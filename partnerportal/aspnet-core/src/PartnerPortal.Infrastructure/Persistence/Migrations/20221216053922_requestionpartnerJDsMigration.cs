using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class requestionpartnerJDsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartner_Partners_PartnerId",
                table: "RequisitionPartner");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartner_Requisition_RequestionID",
                table: "RequisitionPartner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisitionPartner",
                table: "RequisitionPartner");

            migrationBuilder.RenameTable(
                name: "RequisitionPartner",
                newName: "RequisitionPartners");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionPartner_RequestionID",
                table: "RequisitionPartners",
                newName: "IX_RequisitionPartners_RequestionID");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionPartner_PartnerId",
                table: "RequisitionPartners",
                newName: "IX_RequisitionPartners_PartnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisitionPartners",
                table: "RequisitionPartners",
                column: "RequsitionPartnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartners_Partners_PartnerId",
                table: "RequisitionPartners",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "PartnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartners_Requisition_RequestionID",
                table: "RequisitionPartners",
                column: "RequestionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartners_Partners_PartnerId",
                table: "RequisitionPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionPartners_Requisition_RequestionID",
                table: "RequisitionPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisitionPartners",
                table: "RequisitionPartners");

            migrationBuilder.RenameTable(
                name: "RequisitionPartners",
                newName: "RequisitionPartner");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionPartners_RequestionID",
                table: "RequisitionPartner",
                newName: "IX_RequisitionPartner_RequestionID");

            migrationBuilder.RenameIndex(
                name: "IX_RequisitionPartners_PartnerId",
                table: "RequisitionPartner",
                newName: "IX_RequisitionPartner_PartnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisitionPartner",
                table: "RequisitionPartner",
                column: "RequsitionPartnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartner_Partners_PartnerId",
                table: "RequisitionPartner",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "PartnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionPartner_Requisition_RequestionID",
                table: "RequisitionPartner",
                column: "RequestionID",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

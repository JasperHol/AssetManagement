using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relatie_AssetType_AssetKindId_Opnieuw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_AssetKindId",
                table: "AssetTypes",
                column: "AssetKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_AssetKinds_AssetKindId",
                table: "AssetTypes",
                column: "AssetKindId",
                principalTable: "AssetKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_AssetKinds_AssetKindId",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_AssetKindId",
                table: "AssetTypes");
        }
    }
}

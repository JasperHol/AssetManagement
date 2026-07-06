using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class assettype_model_relationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_ModelId",
                table: "AssetTypes",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_Models_ModelId",
                table: "AssetTypes",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_Models_ModelId",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_ModelId",
                table: "AssetTypes");
        }
    }
}

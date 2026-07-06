using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relataieassetkindtoevoegen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_Models_ModelId",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_ModelId",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<int>(
                name: "AssetKindId",
                table: "AssetTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AssetKindId",
                table: "AssetTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}

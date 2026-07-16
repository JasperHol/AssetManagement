using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusTransitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransitions_StatusFromId",
                table: "StatusTransitions",
                column: "StatusFromId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransitions_StatusToId",
                table: "StatusTransitions",
                column: "StatusToId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTransitions_Status_StatusFromId",
                table: "StatusTransitions",
                column: "StatusFromId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTransitions_Status_StatusToId",
                table: "StatusTransitions",
                column: "StatusToId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusTransitions_Status_StatusFromId",
                table: "StatusTransitions");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTransitions_Status_StatusToId",
                table: "StatusTransitions");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_StatusTransitions_StatusFromId",
                table: "StatusTransitions");

            migrationBuilder.DropIndex(
                name: "IX_StatusTransitions_StatusToId",
                table: "StatusTransitions");
        }
    }
}

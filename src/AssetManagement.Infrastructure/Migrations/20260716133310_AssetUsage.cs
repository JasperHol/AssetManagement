using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssetUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AgreementStatus = table.Column<int>(type: "int", nullable: false),
                    AgreemnentSignDate = table.Column<DateTime>(type: "date", nullable: false),
                    AgreementDeclineDate = table.Column<DateTime>(type: "date", nullable: false),
                    AgreementDeclineReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AgreementUsageAgreementImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PersonAssetUsageId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    AgreementStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetUsages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetUsages");
        }
    }
}

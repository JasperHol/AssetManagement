using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class person_location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AssetKinds",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        HasMacAddress = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
            //        IsPhysical = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AssetKinds", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Assets",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Brand = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        SerialNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        MacAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        ServiceTag = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        PurchaseDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        OrderNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        LostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DisposedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CmdbLabel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        DepreciationDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        MsLicenceMappingId = table.Column<int>(type: "int", nullable: false),
            //        StatusId = table.Column<int>(type: "int", nullable: false),
            //        AssetTypeId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Assets", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Assets_Assets_AssetTypeId",
            //            column: x => x.AssetTypeId,
            //            principalTable: "Assets",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AuditLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        EntityId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        ChangedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        Changes = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AuditLogs", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ReportingUnitId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Requestable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Manufacturers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
            //        Requestable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Manufacturers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Requestable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmloyeeNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WorksForId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Statuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        StatusTransitionId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Statuses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StatusTransitions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StatusFromId = table.Column<int>(type: "int", nullable: false),
            //        StatusToId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StatusTransitions", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Models",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
            //        Requestable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
            //        ManufacturerId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Models", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Models_Manufacturers_ManufacturerId",
            //            column: x => x.ManufacturerId,
            //            principalTable: "Manufacturers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AssetTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
            //        Requestable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
            //        DepreciationValue = table.Column<int>(type: "int", nullable: false),
            //        DepreciationPeriod = table.Column<int>(type: "int", nullable: false),
            //        DataSource = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        JiraId = table.Column<int>(type: "int", nullable: false),
            //        PrefixName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
            //        SecuritySensitive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
            //        MobileEquipment = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
            //        ModelId = table.Column<int>(type: "int", nullable: false),
            //        AssetKindId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AssetTypes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AssetTypes_AssetKinds_AssetKindId",
            //            column: x => x.AssetKindId,
            //            principalTable: "AssetKinds",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AssetTypes_Models_ModelId",
            //            column: x => x.ModelId,
            //            principalTable: "Models",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.InsertData(
            //    table: "StatusTransitions",
            //    columns: new[] { "Id", "StatusFromId", "StatusToId" },
            //    values: new object[,]
            //    {
            //        { 1, 1, 6 },
            //        { 2, 1, 3 },
            //        { 3, 2, 3 },
            //        { 4, 2, 4 },
            //        { 5, 2, 6 },
            //        { 6, 2, 5 },
            //        { 7, 3, 5 },
            //        { 8, 3, 2 },
            //        { 9, 3, 4 },
            //        { 10, 4, 6 },
            //        { 11, 4, 2 },
            //        { 12, 4, 3 },
            //        { 13, 5, 8 },
            //        { 14, 5, 6 },
            //        { 15, 5, 3 },
            //        { 16, 5, 2 },
            //        { 17, 6, 7 },
            //        { 18, 6, 2 },
            //        { 19, 6, 4 },
            //        { 20, 6, 5 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Statuses",
            //    columns: new[] { "Id", "Name", "StatusTransitionId" },
            //    values: new object[,]
            //    {
            //        { 1, "CreateAsset", 1 },
            //        { 2, "Stock", 2 },
            //        { 3, "InUse", 3 },
            //        { 4, "AssetInServiceRepair", 4 },
            //        { 5, "ReportedStolenMissing", 5 },
            //        { 6, "ObsoleteAsset", 6 },
            //        { 7, "AssetDisposed", 7 },
            //        { 8, "AssetLost", 8 }
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Assets_AssetTypeId",
            //    table: "Assets",
            //    column: "AssetTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AssetTypes_AssetKindId",
            //    table: "AssetTypes",
            //    column: "AssetKindId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AssetTypes_ModelId",
            //    table: "AssetTypes",
            //    column: "ModelId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Models_ManufacturerId",
            //    table: "Models",
            //    column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "StatusTransitions");

            migrationBuilder.DropTable(
                name: "AssetKinds");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}

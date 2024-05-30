using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoTrader.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraderDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraderDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraderId = table.Column<int>(type: "int", nullable: false),
                    TradersId = table.Column<int>(type: "int", nullable: true),
                    CryptoId = table.Column<int>(type: "int", nullable: false),
                    CryptoDataId = table.Column<int>(type: "int", nullable: true),
                    ValueSum = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDatas_CryptoDatas_CryptoDataId",
                        column: x => x.CryptoDataId,
                        principalTable: "CryptoDatas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDatas_TraderDatas_TradersId",
                        column: x => x.TradersId,
                        principalTable: "TraderDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDatas_CryptoDataId",
                table: "OrderDatas",
                column: "CryptoDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDatas_TradersId",
                table: "OrderDatas",
                column: "TradersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDatas");

            migrationBuilder.DropTable(
                name: "CryptoDatas");

            migrationBuilder.DropTable(
                name: "TraderDatas");
        }
    }
}

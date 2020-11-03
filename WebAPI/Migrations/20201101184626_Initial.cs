using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    DataOpen = table.Column<DateTime>(nullable: false),
                    DataClose = table.Column<DateTime>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inn = table.Column<long>(nullable: false),
                    Type = table.Column<bool>(nullable: false),
                    Shifer = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusAggrement = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAggrement = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Agreement",
                columns: new[] { "Id", "DataClose", "DataOpen", "Number", "PersonId", "StatusId", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 2 },
                    { 2, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 1 },
                    { 3, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1, 3 },
                    { 4, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Data", "Inn", "Shifer", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 122365456212L, "sdada", false },
                    { 2, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 122515456212L, "shfgha", false },
                    { 3, new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225154562L, "ssdfgha", true },
                    { 4, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227545621L, "sjhk", true },
                    { 5, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 122516556212L, "rtya", false },
                    { 6, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1287545621L, "ssyio", true }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "StatusAggrement" },
                values: new object[,]
                {
                    { 1, "действует" },
                    { 2, "блокирован" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "TypeAggrement" },
                values: new object[,]
                {
                    { 1, "дилерский" },
                    { 2, "брокерский" },
                    { 3, "управления" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}

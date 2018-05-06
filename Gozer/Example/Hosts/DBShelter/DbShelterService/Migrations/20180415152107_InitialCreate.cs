using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DbShelterService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    AssambliQualifiedName = table.Column<string>(nullable: true),
                    Binding = table.Column<int>(nullable: false),
                    EndpointAdress = table.Column<string>(nullable: true),
                    LastCall = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Service", x => x.Guid); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
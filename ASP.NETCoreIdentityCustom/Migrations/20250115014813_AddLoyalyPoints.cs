﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyIceDream.Migrations
{
    public partial class AddLoyalyPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoyaltyPoints",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "Orders");
        }
    }
}

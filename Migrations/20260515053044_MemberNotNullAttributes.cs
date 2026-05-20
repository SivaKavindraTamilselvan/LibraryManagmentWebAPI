using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class MemberNotNullAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Type",
                table: "Member");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "Member",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "MemberTypeId",
                table: "Member",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Type",
                table: "Member",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "MemberTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Type",
                table: "Member");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "Member",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberTypeId",
                table: "Member",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Type",
                table: "Member",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "MemberTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

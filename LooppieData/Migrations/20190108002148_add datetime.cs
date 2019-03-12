using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LooppieData.Migrations
{
    public partial class adddatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionCreatTime",
                table: "Question",
                newName: "QuestionCreateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "UserCreateTime",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AnswerRecordCreateTime",
                table: "QuestionAnswerRecord",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreateTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AnswerRecordCreateTime",
                table: "QuestionAnswerRecord");

            migrationBuilder.RenameColumn(
                name: "QuestionCreateTime",
                table: "Question",
                newName: "QuestionCreatTime");
        }
    }
}

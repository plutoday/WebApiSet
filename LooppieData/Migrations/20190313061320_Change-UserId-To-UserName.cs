using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LooppieData.Migrations
{
    public partial class ChangeUserIdToUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswererId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropColumn(
                name: "SubmitterId",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "Answerer",
                table: "QuestionAnswerRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Submitter",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answerer",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropColumn(
                name: "Submitter",
                table: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswererId",
                table: "QuestionAnswerRecord",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubmitterId",
                table: "Question",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

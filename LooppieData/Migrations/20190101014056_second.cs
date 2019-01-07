using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LooppieData.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_User_SubmitterUserId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerRecord_User_AnswererUserId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerRecord_Question_QuestionId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswerRecord_AnswererUserId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswerRecord_QuestionId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropIndex(
                name: "IX_Question_SubmitterUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AnswererUserId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropColumn(
                name: "SubmitterUserId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "Explaination",
                table: "Answer",
                newName: "Explanation");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "QuestionAnswerRecord",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AnswererId",
                table: "QuestionAnswerRecord",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "SubCategory",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "SubmitterId",
                table: "Question",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswererId",
                table: "QuestionAnswerRecord");

            migrationBuilder.DropColumn(
                name: "SubmitterId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "Explanation",
                table: "Answer",
                newName: "Explaination");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "QuestionAnswerRecord",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AnswererUserId",
                table: "QuestionAnswerRecord",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubCategory",
                table: "Question",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Question",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubmitterUserId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId1",
                table: "User",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerRecord_AnswererUserId",
                table: "QuestionAnswerRecord",
                column: "AnswererUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerRecord_QuestionId",
                table: "QuestionAnswerRecord",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SubmitterUserId",
                table: "Question",
                column: "SubmitterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_User_SubmitterUserId",
                table: "Question",
                column: "SubmitterUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerRecord_User_AnswererUserId",
                table: "QuestionAnswerRecord",
                column: "AnswererUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerRecord_Question_QuestionId",
                table: "QuestionAnswerRecord",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserId1",
                table: "User",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

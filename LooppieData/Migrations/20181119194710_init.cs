using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LooppieData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ActiveUser = table.Column<bool>(nullable: false),
                    UserId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(nullable: false),
                    SubmitterUserId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    SubCategory = table.Column<int>(nullable: false),
                    HotRank = table.Column<int>(nullable: false),
                    QuestionCreatTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Question_User_SubmitterUserId",
                        column: x => x.SubmitterUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HitCount = table.Column<int>(nullable: false),
                    Explaination = table.Column<string>(nullable: true),
                    QuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswerRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AnswererUserId = table.Column<Guid>(nullable: true),
                    QuestionId = table.Column<Guid>(nullable: true),
                    Answer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerRecord_User_AnswererUserId",
                        column: x => x.AnswererUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerRecord_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SubmitterUserId",
                table: "Question",
                column: "SubmitterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerRecord_AnswererUserId",
                table: "QuestionAnswerRecord",
                column: "AnswererUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerRecord_QuestionId",
                table: "QuestionAnswerRecord",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId1",
                table: "User",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "QuestionAnswerRecord");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

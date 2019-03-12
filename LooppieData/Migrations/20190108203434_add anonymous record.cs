using Microsoft.EntityFrameworkCore.Migrations;

namespace LooppieData.Migrations
{
    public partial class addanonymousrecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anonymous",
                table: "QuestionAnswerRecord",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anonymous",
                table: "QuestionAnswerRecord");
        }
    }
}

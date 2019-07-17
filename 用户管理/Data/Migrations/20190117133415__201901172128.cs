using Microsoft.EntityFrameworkCore.Migrations;

namespace 用户管理.Data.Migrations
{
    public partial class _201901172128 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDCard",
                table: "AspNetUsers",
                maxLength: 18,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCard",
                table: "AspNetUsers");
        }
    }
}

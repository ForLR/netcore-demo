using Microsoft.EntityFrameworkCore.Migrations;

namespace 用户管理.Data.Migrations
{
    public partial class _201901242105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "AspNetUsers");
        }
    }
}

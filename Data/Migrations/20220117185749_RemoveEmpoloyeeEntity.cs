using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    public partial class RemoveEmpoloyeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectActivities_Users_EmployeeId",
                table: "ProjectActivities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SSN",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ProjectActivities",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectActivities_EmployeeId",
                table: "ProjectActivities",
                newName: "IX_ProjectActivities_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectActivities_Users_ApplicationUserId",
                table: "ProjectActivities",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectActivities_Users_ApplicationUserId",
                table: "ProjectActivities");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ProjectActivities",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectActivities_ApplicationUserId",
                table: "ProjectActivities",
                newName: "IX_ProjectActivities_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SSN",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectActivities_Users_EmployeeId",
                table: "ProjectActivities",
                column: "EmployeeId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

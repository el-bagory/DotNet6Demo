using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    public partial class createEmpoloyeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Room_ToRoomId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_FromUserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_AutherId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImage_Post_PostId",
                table: "PostImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Department_DepartmentId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Post_PostId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Project_ProjectId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostImage",
                table: "PostImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "PostImage",
                newName: "postImages");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_PostId",
                table: "Tags",
                newName: "IX_Tags_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_DepartmentId",
                table: "Projects",
                newName: "IX_Projects_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PostImage_PostId",
                table: "postImages",
                newName: "IX_postImages_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_AutherId",
                table: "Posts",
                newName: "IX_Posts_AutherId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ToRoomId",
                table: "Messages",
                newName: "IX_Messages_ToRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_FromUserId",
                table: "Messages",
                newName: "IX_Messages_FromUserId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_postImages",
                table: "postImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Room_ToRoomId",
                table: "Messages",
                column: "ToRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_postImages_Posts_PostId",
                table: "postImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AutherId",
                table: "Posts",
                column: "AutherId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Department_DepartmentId",
                table: "Projects",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_ProjectId",
                schema: "security",
                table: "Users",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Room_ToRoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_postImages_Posts_PostId",
                table: "postImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AutherId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Department_DepartmentId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_postImages",
                table: "postImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SSN",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "postImages",
                newName: "PostImage");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_PostId",
                table: "Tag",
                newName: "IX_Tag_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_DepartmentId",
                table: "Project",
                newName: "IX_Project_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AutherId",
                table: "Post",
                newName: "IX_Post_AutherId");

            migrationBuilder.RenameIndex(
                name: "IX_postImages_PostId",
                table: "PostImage",
                newName: "IX_PostImage_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToRoomId",
                table: "Message",
                newName: "IX_Message_ToRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserId",
                table: "Message",
                newName: "IX_Message_FromUserId");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostImage",
                table: "PostImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Room_ToRoomId",
                table: "Message",
                column: "ToRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_FromUserId",
                table: "Message",
                column: "FromUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_AutherId",
                table: "Post",
                column: "AutherId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImage_Post_PostId",
                table: "PostImage",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Department_DepartmentId",
                table: "Project",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Post_PostId",
                table: "Tag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Project_ProjectId",
                schema: "security",
                table: "Users",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}

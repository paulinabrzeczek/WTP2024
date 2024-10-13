using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WTP2024.Migrations
{
    /// <inheritdoc />
    public partial class EntityName_DDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_BeerDb_BeerId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_UserDb_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDb_Roles_RoleId",
                table: "UserDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDb",
                table: "UserDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerDb",
                table: "BeerDb");

            migrationBuilder.RenameTable(
                name: "UserDb",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "BeerDb",
                newName: "Beers");

            migrationBuilder.RenameIndex(
                name: "IX_UserDb_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beers",
                table: "Beers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Beers_BeerId",
                table: "Ratings",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Beers_BeerId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beers",
                table: "Beers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserDb");

            migrationBuilder.RenameTable(
                name: "Beers",
                newName: "BeerDb");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "UserDb",
                newName: "IX_UserDb_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDb",
                table: "UserDb",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerDb",
                table: "BeerDb",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_BeerDb_BeerId",
                table: "Ratings",
                column: "BeerId",
                principalTable: "BeerDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_UserDb_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "UserDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDb_Roles_RoleId",
                table: "UserDb",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _21infinity_rekrutacja_core.Migrations
{
    /// <inheritdoc />
    public partial class AddedOwnerfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Training_User_account_OwnerId",
                table: "Training",
                column: "OwnerId",
                principalTable: "User_account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_User_account_OwnerId",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_OwnerId",
                table: "Training");
        }
    }
}

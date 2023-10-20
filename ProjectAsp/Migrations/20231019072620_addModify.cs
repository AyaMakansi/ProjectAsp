using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAsp.Migrations
{
    /// <inheritdoc />
    public partial class addModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parent_idId",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_parent_idId",
                table: "Branches",
                column: "parent_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Branches_parent_idId",
                table: "Branches",
                column: "parent_idId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Branches_parent_idId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_parent_idId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "parent_idId",
                table: "Branches");
        }
    }
}

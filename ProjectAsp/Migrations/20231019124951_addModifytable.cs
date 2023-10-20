using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAsp.Migrations
{
    /// <inheritdoc />
    public partial class addModifytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Branches_parent_idId",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "parent_idId",
                table: "Branches",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_parent_idId",
                table: "Branches",
                newName: "IX_Branches_ParentId");

            migrationBuilder.AddColumn<int>(
                name: "Branch_Id",
                table: "Branches",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Branches_ParentId",
                table: "Branches",
                column: "ParentId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Branches_ParentId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Branch_Id",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Branches",
                newName: "parent_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_ParentId",
                table: "Branches",
                newName: "IX_Branches_parent_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Branches_parent_idId",
                table: "Branches",
                column: "parent_idId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

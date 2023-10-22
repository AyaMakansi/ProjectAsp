using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAsp.Migrations
{
    /// <inheritdoc />
    public partial class addmigreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Branches_ParentId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Companies_companyComp_Id",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Products_productId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_productId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Branches_companyComp_Id",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "companyComp_Id",
                table: "Branches");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Branches",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Branches_ParentId",
                table: "Branches",
                column: "ParentId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Branches_ParentId",
                table: "Branches");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Operations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "companyComp_Id",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_productId",
                table: "Operations",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_companyComp_Id",
                table: "Branches",
                column: "companyComp_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Branches_ParentId",
                table: "Branches",
                column: "ParentId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Companies_companyComp_Id",
                table: "Branches",
                column: "companyComp_Id",
                principalTable: "Companies",
                principalColumn: "Comp_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Products_productId",
                table: "Operations",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Letgo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modidfyAdvert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_hierarchicalCategories_hierarchicalCategoriesId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_hierarchicalCategoriesId",
                table: "Adverts");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "dccca977-55cb-4d3f-94b7-6f512331dae9",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6644a519-9e82-4f96-8dff-63fe1d1b0783");

            migrationBuilder.AddColumn<string>(
                name: "AdvertObjectID",
                table: "hierarchicalCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "c1bab958-f48b-488c-a455-d25f114b3022",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "27862e9a-c709-4835-9aca-dd865bfc9048");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "d686acf3-95aa-4086-b815-58a75fbe0fc3",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6d7c25a3-64aa-428d-b8c1-259f9a11c868");

            migrationBuilder.AlterColumn<string>(
                name: "hierarchicalCategoriesId",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "e02833e2-d4c9-4555-a110-4c6b260e8324",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "720db885-b4a8-4c44-bda6-280c3cc613e6");

            migrationBuilder.CreateIndex(
                name: "IX_hierarchicalCategories_AdvertObjectID",
                table: "hierarchicalCategories",
                column: "AdvertObjectID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_hierarchicalCategories_Adverts_AdvertObjectID",
                table: "hierarchicalCategories",
                column: "AdvertObjectID",
                principalTable: "Adverts",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hierarchicalCategories_Adverts_AdvertObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.DropIndex(
                name: "IX_hierarchicalCategories_AdvertObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.DropColumn(
                name: "AdvertObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6644a519-9e82-4f96-8dff-63fe1d1b0783",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "dccca977-55cb-4d3f-94b7-6f512331dae9");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "27862e9a-c709-4835-9aca-dd865bfc9048",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "c1bab958-f48b-488c-a455-d25f114b3022");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6d7c25a3-64aa-428d-b8c1-259f9a11c868",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "d686acf3-95aa-4086-b815-58a75fbe0fc3");

            migrationBuilder.AlterColumn<string>(
                name: "hierarchicalCategoriesId",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "720db885-b4a8-4c44-bda6-280c3cc613e6",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "e02833e2-d4c9-4555-a110-4c6b260e8324");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_hierarchicalCategoriesId",
                table: "Adverts",
                column: "hierarchicalCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_hierarchicalCategories_hierarchicalCategoriesId",
                table: "Adverts",
                column: "hierarchicalCategoriesId",
                principalTable: "hierarchicalCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

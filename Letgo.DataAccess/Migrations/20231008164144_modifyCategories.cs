using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Letgo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hierarchicalCategories_Adverts_AdvertObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hierarchicalCategories",
                table: "hierarchicalCategories");

            migrationBuilder.DropIndex(
                name: "IX_hierarchicalCategories_AdvertObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.RenameTable(
                name: "hierarchicalCategories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_hierarchicalCategories_ObjectID",
                table: "Categories",
                newName: "IX_Categories_ObjectID");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "444bb712-72df-4f75-a65a-e8232f46073f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "fbbc18c2-9651-4ae0-8072-8f41d273342e");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "ee1978d8-ae21-43b1-8329-1a09e61d5d92",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "b686379d-3b15-4c6c-960e-9e80bbaec898");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "cd5040dd-326b-493e-af02-8c2b0947b4fd",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "64feda21-8643-4b51-9719-8465c5f770c4");

            migrationBuilder.AlterColumn<string>(
                name: "hierarchicalCategoriesObjectID",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "36daa247-c273-4be3-8f41-1c2dd9b47176",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "ab109e17-2b6f-4810-bc87-fd6857675ca8");

            migrationBuilder.AlterColumn<string>(
                name: "AdvertObjectID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "14b43520-4bb4-4517-b490-bc7338cc7a0b",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "bd6a3bfe-2758-484f-af72-7415c2f49566");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AdvertObjectID",
                table: "Categories",
                column: "AdvertObjectID",
                unique: true,
                filter: "[AdvertObjectID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Adverts_AdvertObjectID",
                table: "Categories",
                column: "AdvertObjectID",
                principalTable: "Adverts",
                principalColumn: "ObjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Adverts_AdvertObjectID",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AdvertObjectID",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "hierarchicalCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ObjectID",
                table: "hierarchicalCategories",
                newName: "IX_hierarchicalCategories_ObjectID");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "fbbc18c2-9651-4ae0-8072-8f41d273342e",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "444bb712-72df-4f75-a65a-e8232f46073f");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "b686379d-3b15-4c6c-960e-9e80bbaec898",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "ee1978d8-ae21-43b1-8329-1a09e61d5d92");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "64feda21-8643-4b51-9719-8465c5f770c4",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "cd5040dd-326b-493e-af02-8c2b0947b4fd");

            migrationBuilder.AlterColumn<string>(
                name: "hierarchicalCategoriesObjectID",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "ab109e17-2b6f-4810-bc87-fd6857675ca8",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "36daa247-c273-4be3-8f41-1c2dd9b47176");

            migrationBuilder.AlterColumn<string>(
                name: "AdvertObjectID",
                table: "hierarchicalCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "hierarchicalCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "bd6a3bfe-2758-484f-af72-7415c2f49566",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "14b43520-4bb4-4517-b490-bc7338cc7a0b");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hierarchicalCategories",
                table: "hierarchicalCategories",
                column: "ObjectID");

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
    }
}

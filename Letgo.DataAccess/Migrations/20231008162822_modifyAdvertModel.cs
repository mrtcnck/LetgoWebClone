using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Letgo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyAdvertModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hierarchicalCategories",
                table: "hierarchicalCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "hierarchicalCategories");

            migrationBuilder.RenameColumn(
                name: "hierarchicalCategoriesId",
                table: "Adverts",
                newName: "hierarchicalCategoriesObjectID");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "fbbc18c2-9651-4ae0-8072-8f41d273342e",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "dccca977-55cb-4d3f-94b7-6f512331dae9");

            migrationBuilder.AddColumn<string>(
                name: "ObjectID",
                table: "hierarchicalCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "bd6a3bfe-2758-484f-af72-7415c2f49566");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "hierarchicalCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "hierarchicalCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "b686379d-3b15-4c6c-960e-9e80bbaec898",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "c1bab958-f48b-488c-a455-d25f114b3022");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "64feda21-8643-4b51-9719-8465c5f770c4",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "d686acf3-95aa-4086-b815-58a75fbe0fc3");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "ab109e17-2b6f-4810-bc87-fd6857675ca8",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "e02833e2-d4c9-4555-a110-4c6b260e8324");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hierarchicalCategories",
                table: "hierarchicalCategories",
                column: "ObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_hierarchicalCategories_ObjectID",
                table: "hierarchicalCategories",
                column: "ObjectID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hierarchicalCategories",
                table: "hierarchicalCategories");

            migrationBuilder.DropIndex(
                name: "IX_hierarchicalCategories_ObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.DropColumn(
                name: "ObjectID",
                table: "hierarchicalCategories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "hierarchicalCategories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "hierarchicalCategories");

            migrationBuilder.RenameColumn(
                name: "hierarchicalCategoriesObjectID",
                table: "Adverts",
                newName: "hierarchicalCategoriesId");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "dccca977-55cb-4d3f-94b7-6f512331dae9",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "fbbc18c2-9651-4ae0-8072-8f41d273342e");

            migrationBuilder.AddColumn<string>(
                name: "Id",
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
                oldDefaultValue: "b686379d-3b15-4c6c-960e-9e80bbaec898");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "d686acf3-95aa-4086-b815-58a75fbe0fc3",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "64feda21-8643-4b51-9719-8465c5f770c4");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "e02833e2-d4c9-4555-a110-4c6b260e8324",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "ab109e17-2b6f-4810-bc87-fd6857675ca8");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hierarchicalCategories",
                table: "hierarchicalCategories",
                column: "Id");
        }
    }
}

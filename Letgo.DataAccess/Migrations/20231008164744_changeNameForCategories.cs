using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Letgo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeNameForCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hierarchicalCategoriesObjectID",
                table: "Adverts",
                newName: "CategoriesObjectID");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "81abc910-8e96-47f9-834d-5ec72ad2ce0f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "444bb712-72df-4f75-a65a-e8232f46073f");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "9ff1cfe7-1f08-4051-8250-535406513ecb",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "ee1978d8-ae21-43b1-8329-1a09e61d5d92");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "dac00460-b559-4d3f-a104-ac4818a32625",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "14b43520-4bb4-4517-b490-bc7338cc7a0b");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7e452a5d-2747-40c6-80ff-27e8b72c2e67",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "cd5040dd-326b-493e-af02-8c2b0947b4fd");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "b473c92f-dc21-43b0-9c7d-693ddba075dd",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "36daa247-c273-4be3-8f41-1c2dd9b47176");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriesObjectID",
                table: "Adverts",
                newName: "hierarchicalCategoriesObjectID");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "444bb712-72df-4f75-a65a-e8232f46073f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "81abc910-8e96-47f9-834d-5ec72ad2ce0f");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "ee1978d8-ae21-43b1-8329-1a09e61d5d92",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "9ff1cfe7-1f08-4051-8250-535406513ecb");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "14b43520-4bb4-4517-b490-bc7338cc7a0b",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "dac00460-b559-4d3f-a104-ac4818a32625");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "cd5040dd-326b-493e-af02-8c2b0947b4fd",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7e452a5d-2747-40c6-80ff-27e8b72c2e67");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectID",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "36daa247-c273-4be3-8f41-1c2dd9b47176",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "b473c92f-dc21-43b0-9c7d-693ddba075dd");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Letgo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifiedFavoriteProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProducts_Adverts_AdvertId",
                table: "FavoriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProducts_AspNetUsers_UserId",
                table: "FavoriteProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProducts",
                table: "FavoriteProducts");

            migrationBuilder.RenameTable(
                name: "FavoriteProducts",
                newName: "FavoriteAdverts");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProducts_UserId",
                table: "FavoriteAdverts",
                newName: "IX_FavoriteAdverts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProducts_Id",
                table: "FavoriteAdverts",
                newName: "IX_FavoriteAdverts_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteProducts_AdvertId",
                table: "FavoriteAdverts",
                newName: "IX_FavoriteAdverts_AdvertId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "f637a07a-6ade-431c-9b47-f10deed5f92f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "e12f1c14-059a-420c-8cfb-e187bb9579b8");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7467da20-594a-41b4-9fd3-d87962470a22",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "e2a79302-531b-4955-897c-58f5690a5d67");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "5d6774f3-9864-4d8e-a628-f494b91603bb",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "2e000ffd-9c88-4030-81d2-7be43ec013a0");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "817fc46f-485d-4deb-a909-23c1b3e81208",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "d32795d5-bc8a-44ec-91d3-06ff0c7e04bb");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "FavoriteAdverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7f35cd96-1e65-4080-a87c-396c95f1e9be",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "02c4061a-d883-40ac-8453-8372fba1b857");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteAdverts",
                table: "FavoriteAdverts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteAdverts_Adverts_AdvertId",
                table: "FavoriteAdverts",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteAdverts_AspNetUsers_UserId",
                table: "FavoriteAdverts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteAdverts_Adverts_AdvertId",
                table: "FavoriteAdverts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteAdverts_AspNetUsers_UserId",
                table: "FavoriteAdverts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteAdverts",
                table: "FavoriteAdverts");

            migrationBuilder.RenameTable(
                name: "FavoriteAdverts",
                newName: "FavoriteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteAdverts_UserId",
                table: "FavoriteProducts",
                newName: "IX_FavoriteProducts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteAdverts_Id",
                table: "FavoriteProducts",
                newName: "IX_FavoriteProducts_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteAdverts_AdvertId",
                table: "FavoriteProducts",
                newName: "IX_FavoriteProducts_AdvertId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "e12f1c14-059a-420c-8cfb-e187bb9579b8",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "f637a07a-6ade-431c-9b47-f10deed5f92f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "e2a79302-531b-4955-897c-58f5690a5d67",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7467da20-594a-41b4-9fd3-d87962470a22");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AdvertStatues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "2e000ffd-9c88-4030-81d2-7be43ec013a0",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "5d6774f3-9864-4d8e-a628-f494b91603bb");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "d32795d5-bc8a-44ec-91d3-06ff0c7e04bb",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "817fc46f-485d-4deb-a909-23c1b3e81208");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "FavoriteProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "02c4061a-d883-40ac-8453-8372fba1b857",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7f35cd96-1e65-4080-a87c-396c95f1e9be");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProducts",
                table: "FavoriteProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProducts_Adverts_AdvertId",
                table: "FavoriteProducts",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProducts_AspNetUsers_UserId",
                table: "FavoriteProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

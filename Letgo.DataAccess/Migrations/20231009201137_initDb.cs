using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Letgo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertStatues",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "da657719-60c9-4a22-ac86-acdae3372e04"),
                    AdvertObjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnAir = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDenied = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsModify = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertStatues", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "2d6f47e9-b8ca-4317-8ab0-d9d9bb4d2e64"),
                    Point = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    AssessedId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluatedId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "5f4215b9-2cea-4fd0-9691-3856e403495e"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusObjectID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SellerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoriesObjectID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatHistoryObjectID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_Adverts_AdvertStatues_StatusObjectID",
                        column: x => x.StatusObjectID,
                        principalTable: "AdvertStatues",
                        principalColumn: "ObjectID");
                    table.ForeignKey(
                        name: "FK_Adverts_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "27d9aa17-fb5c-4602-9726-8067c9fef145"),
                    Lvl0 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lvl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertObjectID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_Categories_Adverts_AdvertObjectID",
                        column: x => x.AdvertObjectID,
                        principalTable: "Adverts",
                        principalColumn: "ObjectID");
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "9078f949-8248-457a-9313-edcdfe0acf1d"),
                    AdvertObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_Chats_Adverts_AdvertObjectID",
                        column: x => x.AdvertObjectID,
                        principalTable: "Adverts",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteAdverts",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "c74dd292-215b-47a0-b018-2e332339592d"),
                    AdvertObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAdverts", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_FavoriteAdverts_Adverts_AdvertObjectID",
                        column: x => x.AdvertObjectID,
                        principalTable: "Adverts",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteAdverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatHistories",
                columns: table => new
                {
                    ObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "488cb25f-a8bd-4a7e-9c02-548225840789"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatObjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatHistories", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_ChatHistories_Chats_ChatObjectID",
                        column: x => x.ChatObjectID,
                        principalTable: "Chats",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ChatHistoryObjectID",
                table: "Adverts",
                column: "ChatHistoryObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ObjectID",
                table: "Adverts",
                column: "ObjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_SellerId",
                table: "Adverts",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_Slug",
                table: "Adverts",
                column: "Slug",
                unique: true,
                filter: "[Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_StatusObjectID",
                table: "Adverts",
                column: "StatusObjectID",
                unique: true,
                filter: "[StatusObjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertStatues_ObjectID",
                table: "AdvertStatues",
                column: "ObjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AdvertObjectID",
                table: "Categories",
                column: "AdvertObjectID",
                unique: true,
                filter: "[AdvertObjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ObjectID",
                table: "Categories",
                column: "ObjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatHistories_ChatObjectID",
                table: "ChatHistories",
                column: "ChatObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatHistories_ObjectID",
                table: "ChatHistories",
                column: "ObjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AdvertObjectID",
                table: "Chats",
                column: "AdvertObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ObjectID",
                table: "Chats",
                column: "ObjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAdverts_AdvertObjectID",
                table: "FavoriteAdverts",
                column: "AdvertObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAdverts_ObjectID",
                table: "FavoriteAdverts",
                column: "ObjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAdverts_UserId",
                table: "FavoriteAdverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ObjectID",
                table: "Reviews",
                column: "ObjectID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_ChatHistories_ChatHistoryObjectID",
                table: "Adverts",
                column: "ChatHistoryObjectID",
                principalTable: "ChatHistories",
                principalColumn: "ObjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AdvertStatues_StatusObjectID",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AspNetUsers_SellerId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_ChatHistories_ChatHistoryObjectID",
                table: "Adverts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FavoriteAdverts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AdvertStatues");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChatHistories");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Adverts");
        }
    }
}

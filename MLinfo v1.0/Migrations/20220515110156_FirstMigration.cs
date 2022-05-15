using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLinfo_v1._0.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AuthorsInfo",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    AuthorNameE = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    AuthorNameR = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsInfo", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "CountriesInfo",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CountryE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CountryR = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesInfo", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "KeywordsInfo",
                columns: table => new
                {
                    KeywordID = table.Column<int>(type: "int", nullable: false),
                    KeywordE = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    KeywordR = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordsInfo", x => x.KeywordID);
                });

            migrationBuilder.CreateTable(
                name: "MethodMLInfo",
                columns: table => new
                {
                    MethodID = table.Column<int>(type: "int", nullable: false),
                    MethodE = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    MethodR = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodMLInfo", x => x.MethodID);
                });

            migrationBuilder.CreateTable(
                name: "ReferencesInfo",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "int", nullable: false),
                    AuthorsE = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    AuthorsR = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ArticleE = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    ArticleR = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    SourceE = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    SourceR = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    VolumeE = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    VolumeR = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    Number = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    PagesE = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    PagesR = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    DOIE = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    DOIR = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    CommentE = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    CommentR = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    PDF_File = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferencesInfo", x => x.ReferenceID);
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
                name: "OrganizationsInfo",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    OrganizationE = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    OrganizationR = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationsInfo", x => x.OrganizationID);
                    table.ForeignKey(
                        name: "FK_OrganizationsInfo_CountriesInfo",
                        column: x => x.CountryID,
                        principalTable: "CountriesInfo",
                        principalColumn: "CountryID");
                });

            migrationBuilder.CreateTable(
                name: "References_Authors",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References_Authors", x => new { x.ReferenceID, x.AuthorID });
                    table.ForeignKey(
                        name: "FK_References_Authors_AuthorsInfo",
                        column: x => x.AuthorID,
                        principalTable: "AuthorsInfo",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_References_Authors_ReferencesInfo",
                        column: x => x.ReferenceID,
                        principalTable: "ReferencesInfo",
                        principalColumn: "ReferenceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References_Keywords",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "int", nullable: false),
                    KeywordID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References_Keywords_1", x => new { x.ReferenceID, x.KeywordID });
                    table.ForeignKey(
                        name: "FK_References_Keywords_KeywordsInfo",
                        column: x => x.KeywordID,
                        principalTable: "KeywordsInfo",
                        principalColumn: "KeywordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_References_Keywords_ReferencesInfo",
                        column: x => x.ReferenceID,
                        principalTable: "ReferencesInfo",
                        principalColumn: "ReferenceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References_Method",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "int", nullable: false),
                    MethodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References_Method", x => new { x.ReferenceID, x.MethodID });
                    table.ForeignKey(
                        name: "FK_References_Method_MethodMLInfo",
                        column: x => x.MethodID,
                        principalTable: "MethodMLInfo",
                        principalColumn: "MethodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_References_Method_ReferencesInfo",
                        column: x => x.ReferenceID,
                        principalTable: "ReferencesInfo",
                        principalColumn: "ReferenceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors_Organizations",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_Organizations", x => new { x.AuthorID, x.OrganizationID });
                    table.ForeignKey(
                        name: "FK_Authors_Organizations_AuthorsInfo",
                        column: x => x.AuthorID,
                        principalTable: "AuthorsInfo",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Organizations_OrganizationsInfo",
                        column: x => x.OrganizationID,
                        principalTable: "OrganizationsInfo",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Authors_Organizations_OrganizationID",
                table: "Authors_Organizations",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsInfo_CountryID",
                table: "OrganizationsInfo",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_References_Authors_AuthorID",
                table: "References_Authors",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_References_Keywords_KeywordID",
                table: "References_Keywords",
                column: "KeywordID");

            migrationBuilder.CreateIndex(
                name: "IX_References_Method_MethodID",
                table: "References_Method",
                column: "MethodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Authors_Organizations");

            migrationBuilder.DropTable(
                name: "References_Authors");

            migrationBuilder.DropTable(
                name: "References_Keywords");

            migrationBuilder.DropTable(
                name: "References_Method");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrganizationsInfo");

            migrationBuilder.DropTable(
                name: "AuthorsInfo");

            migrationBuilder.DropTable(
                name: "KeywordsInfo");

            migrationBuilder.DropTable(
                name: "MethodMLInfo");

            migrationBuilder.DropTable(
                name: "ReferencesInfo");

            migrationBuilder.DropTable(
                name: "CountriesInfo");
        }
    }
}

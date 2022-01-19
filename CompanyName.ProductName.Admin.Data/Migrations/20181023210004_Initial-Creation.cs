namespace CompanyName.ProductName.Admin.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultValue = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    NameTranslationId = table.Column<int>(nullable: false),
                    CodeTranslationId = table.Column<int>(nullable: false),
                    UnitNameTranslationId = table.Column<int>(nullable: true),
                    PluralNameTranslationId = table.Column<int>(nullable: true),
                    PluralUnitNameTranslationId = table.Column<int>(nullable: true),
                    UnitPrecision = table.Column<byte>(nullable: false),
                    IsNameFeminine = table.Column<bool>(nullable: false),
                    IsUnitNameFeminine = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Translations_CodeTranslationId",
                        column: x => x.CodeTranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currencies_Translations_NameTranslationId",
                        column: x => x.NameTranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currencies_Translations_PluralNameTranslationId",
                        column: x => x.PluralNameTranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currencies_Translations_PluralUnitNameTranslationId",
                        column: x => x.PluralUnitNameTranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currencies_Translations_UnitNameTranslationId",
                        column: x => x.UnitNameTranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NameTranslationID = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Translations_NameTranslationID",
                        column: x => x.NameTranslationID,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdentityName = table.Column<string>(maxLength: 20, nullable: false),
                    NameTranslationID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Translations_NameTranslationID",
                        column: x => x.NameTranslationID,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdentityName = table.Column<string>(maxLength: 20, nullable: false),
                    NameTranslationID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemResources_Translations_NameTranslationID",
                        column: x => x.NameTranslationID,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ISO2 = table.Column<string>(maxLength: 2, nullable: false),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    PhoneCode = table.Column<string>(maxLength: 6, nullable: false),
                    NameTranslationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Translations_NameTranslationId",
                        column: x => x.NameTranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangeRates",
                columns: table => new
                {
                    FromCurrencyId = table.Column<int>(nullable: false),
                    ToCurrencyId = table.Column<int>(nullable: false),
                    BuyRate = table.Column<decimal>(nullable: false),
                    SellRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangeRates", x => new { x.FromCurrencyId, x.ToCurrencyId });
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRates_Currencies_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRates_Currencies_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TranslationEntries",
                columns: table => new
                {
                    TranslationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Translation = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationEntries", x => new { x.TranslationId, x.LanguageId });
                    table.UniqueConstraint("AK_TranslationEntries_LanguageId_TranslationId", x => new { x.LanguageId, x.TranslationId });
                    table.ForeignKey(
                        name: "FK_TranslationEntries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranslationEntries_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NameTranslationId",
                table: "Countries",
                column: "NameTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CodeTranslationId",
                table: "Currencies",
                column: "CodeTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_NameTranslationId",
                table: "Currencies",
                column: "NameTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_PluralNameTranslationId",
                table: "Currencies",
                column: "PluralNameTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_PluralUnitNameTranslationId",
                table: "Currencies",
                column: "PluralUnitNameTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_UnitNameTranslationId",
                table: "Currencies",
                column: "UnitNameTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangeRates_ToCurrencyId",
                table: "CurrencyExchangeRates",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangeRates_FromCurrencyId_ToCurrencyId",
                table: "CurrencyExchangeRates",
                columns: new[] { "FromCurrencyId", "ToCurrencyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_NameTranslationID",
                table: "Languages",
                column: "NameTranslationID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_NameTranslationID",
                table: "Permissions",
                column: "NameTranslationID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemResources_NameTranslationID",
                table: "SystemResources",
                column: "NameTranslationID");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationEntries_TranslationId_LanguageId",
                table: "TranslationEntries",
                columns: new[] { "TranslationId", "LanguageId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CurrencyExchangeRates");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SystemResources");

            migrationBuilder.DropTable(
                name: "TranslationEntries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Translations");
        }
    }
}

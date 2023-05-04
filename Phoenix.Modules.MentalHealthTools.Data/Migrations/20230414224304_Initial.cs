using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.MentalHealthTools.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 70, nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 722, DateTimeKind.Utc).AddTicks(4147)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 722, DateTimeKind.Utc).AddTicks(5588)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHToolsOutbox",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateOccurred = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHToolsOutbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Quote = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Author = table.Column<string>(type: "varchar", maxLength: 70, nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 735, DateTimeKind.Utc).AddTicks(4166)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 735, DateTimeKind.Utc).AddTicks(4988)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    QuoteCategoryId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 70, nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 753, DateTimeKind.Utc).AddTicks(9429)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 754, DateTimeKind.Utc).AddTicks(2787)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_QuoteCategoryId",
                        column: x => x.QuoteCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuoteFavorites",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 70, nullable: false),
                    QuoteId = table.Column<string>(type: "text", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 763, DateTimeKind.Utc).AddTicks(9805)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 764, DateTimeKind.Utc).AddTicks(645)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuoteFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuoteFavorites_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteSubCategoryQuotes",
                columns: table => new
                {
                    QuoteSubCategoriesId = table.Column<string>(type: "text", nullable: false),
                    QuotesId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteSubCategoryQuotes", x => new { x.QuoteSubCategoriesId, x.QuotesId });
                    table.ForeignKey(
                        name: "FK_QuoteSubCategoryQuotes_Quotes_QuotesId",
                        column: x => x.QuotesId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteSubCategoryQuotes_SubCategories_QuoteSubCategoriesId",
                        column: x => x.QuoteSubCategoriesId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteSubCategoryQuotes_QuotesId",
                table: "QuoteSubCategoryQuotes",
                column: "QuotesId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_QuoteCategoryId",
                table: "SubCategories",
                column: "QuoteCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuoteFavorites_QuoteId",
                table: "UserQuoteFavorites",
                column: "QuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MHToolsOutbox");

            migrationBuilder.DropTable(
                name: "QuoteSubCategoryQuotes");

            migrationBuilder.DropTable(
                name: "UserQuoteFavorites");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

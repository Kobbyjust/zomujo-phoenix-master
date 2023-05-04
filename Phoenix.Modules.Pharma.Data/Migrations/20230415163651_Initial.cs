using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.Pharma.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DispatchInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsCollected = table.Column<bool>(type: "boolean", nullable: false),
                    IsDelivered = table.Column<bool>(type: "boolean", nullable: false),
                    PickupCode = table.Column<string>(type: "text", nullable: false),
                    CourierId = table.Column<string>(type: "text", nullable: false),
                    CollectedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 464, DateTimeKind.Utc).AddTicks(5336)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 464, DateTimeKind.Utc).AddTicks(6302)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TradeName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    GenericName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 445, DateTimeKind.Utc).AddTicks(6417)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 445, DateTimeKind.Utc).AddTicks(7975)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaIssues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 453, DateTimeKind.Utc).AddTicks(2914)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 453, DateTimeKind.Utc).AddTicks(3738)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaIssues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaNotifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 457, DateTimeKind.Utc).AddTicks(2572)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 457, DateTimeKind.Utc).AddTicks(3480)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaOutbox",
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
                    table.PrimaryKey("PK_PharmaOutbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaPayments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Amount = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 480, DateTimeKind.Utc).AddTicks(147)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 480, DateTimeKind.Utc).AddTicks(1024)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsFulfilled = table.Column<bool>(type: "boolean", nullable: false),
                    IsProcessed = table.Column<bool>(type: "boolean", nullable: false),
                    PharmaId = table.Column<string>(type: "text", nullable: false),
                    AcceptedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FulfilledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 475, DateTimeKind.Utc).AddTicks(1202)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 475, DateTimeKind.Utc).AddTicks(2165)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ReviewId = table.Column<string>(type: "text", nullable: false),
                    PaymentId = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    ProcessInfoId = table.Column<string>(type: "text", nullable: false),
                    DispatchInfoId = table.Column<string>(type: "text", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 470, DateTimeKind.Utc).AddTicks(1841)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 470, DateTimeKind.Utc).AddTicks(2928)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DispatchInfos_DispatchInfoId",
                        column: x => x.DispatchInfoId,
                        principalTable: "DispatchInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ProcessInfos_ProcessInfoId",
                        column: x => x.ProcessInfoId,
                        principalTable: "ProcessInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugOrder",
                columns: table => new
                {
                    DrugsId = table.Column<string>(type: "text", nullable: false),
                    OrdersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugOrder", x => new { x.DrugsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DrugOrder_Drugs_DrugsId",
                        column: x => x.DrugsId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugOrder_OrdersId",
                table: "DrugOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DispatchInfoId",
                table: "Orders",
                column: "DispatchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProcessInfoId",
                table: "Orders",
                column: "ProcessInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugOrder");

            migrationBuilder.DropTable(
                name: "PharmaIssues");

            migrationBuilder.DropTable(
                name: "PharmaNotifications");

            migrationBuilder.DropTable(
                name: "PharmaOutbox");

            migrationBuilder.DropTable(
                name: "PharmaPayments");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DispatchInfos");

            migrationBuilder.DropTable(
                name: "ProcessInfos");
        }
    }
}

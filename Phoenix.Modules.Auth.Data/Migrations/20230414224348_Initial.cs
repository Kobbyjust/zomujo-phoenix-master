using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.Auth.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(4320)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(5285)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthOutbox",
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
                    table.PrimaryKey("PK_AuthOutbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counsellors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    RateValue = table.Column<int>(name: "Rate_Value", type: "integer", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(4553)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(6694)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counsellors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    Phone = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Photo = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsPhoneVerified = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(694)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(3437)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "varchar", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    ProfilePhoto = table.Column<string>(type: "text", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsPhoneVerified = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 863, DateTimeKind.Utc).AddTicks(9524)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 864, DateTimeKind.Utc).AddTicks(1570)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    LocationAddress = table.Column<string>(name: "Location_Address", type: "text", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsPhoneVerified = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 872, DateTimeKind.Utc).AddTicks(7722)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 873, DateTimeKind.Utc).AddTicks(1353)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(6642)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(8035)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AuthOutbox");

            migrationBuilder.DropTable(
                name: "Counsellors");

            migrationBuilder.DropTable(
                name: "Courier");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

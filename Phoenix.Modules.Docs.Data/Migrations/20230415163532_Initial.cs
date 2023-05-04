using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Phoenix.Modules.Docs.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    DoctorId = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 160, DateTimeKind.Utc).AddTicks(2294)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 160, DateTimeKind.Utc).AddTicks(4399)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocsIssues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 182, DateTimeKind.Utc).AddTicks(4391)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 182, DateTimeKind.Utc).AddTicks(5918)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocsIssues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocsNotifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 194, DateTimeKind.Utc).AddTicks(2915)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 194, DateTimeKind.Utc).AddTicks(4657)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocsNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocsOutbox",
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
                    table.PrimaryKey("PK_DocsOutbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocsPayments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Amount = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 209, DateTimeKind.Utc).AddTicks(9400)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 210, DateTimeKind.Utc).AddTicks(1875)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocsPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Reset = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 297, DateTimeKind.Utc).AddTicks(7075)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 297, DateTimeKind.Utc).AddTicks(8757)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 364, DateTimeKind.Utc).AddTicks(9312)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 365, DateTimeKind.Utc).AddTicks(1899)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    CounsellorId = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    InProgress = table.Column<bool>(type: "boolean", nullable: false),
                    AnonymousName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Feedback = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<int>(type: "integer", nullable: true),
                    Answers = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 393, DateTimeKind.Utc).AddTicks(3552)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 393, DateTimeKind.Utc).AddTicks(5814)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ServiceCategoryId = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 379, DateTimeKind.Utc).AddTicks(8780)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 380, DateTimeKind.Utc).AddTicks(670)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessionMedium",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SessionId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 410, DateTimeKind.Utc).AddTicks(1441)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 410, DateTimeKind.Utc).AddTicks(3229)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionMedium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionMedium_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ServiceId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    PaymentId = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 332, DateTimeKind.Utc).AddTicks(709)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 332, DateTimeKind.Utc).AddTicks(3945)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionnaires_DocsPayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "DocsPayments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questionnaires_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Prompt = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Hint = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 316, DateTimeKind.Utc).AddTicks(2465)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 316, DateTimeKind.Utc).AddTicks(4451)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    QuestionnaireId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    DoctorId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: false),
                    ConsultationId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    IsOrdered = table.Column<bool>(type: "boolean", nullable: false),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 349, DateTimeKind.Utc).AddTicks(3686)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 349, DateTimeKind.Utc).AddTicks(6582)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    MoreInfo = table.Column<string>(type: "text", nullable: true),
                    QuestionId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    QuestionnaireId = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 244, DateTimeKind.Utc).AddTicks(8237)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 245, DateTimeKind.Utc).AddTicks(1782)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionQuestion",
                columns: table => new
                {
                    OptionsId = table.Column<string>(type: "text", nullable: false),
                    QuestionsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionQuestion", x => new { x.OptionsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_OptionQuestion_Options_OptionsId",
                        column: x => x.OptionsId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    DoctorId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 70, nullable: false),
                    MoreInfo = table.Column<string>(type: "text", nullable: true),
                    ReviewId = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 225, DateTimeKind.Utc).AddTicks(5608)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 225, DateTimeKind.Utc).AddTicks(8147)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    AnswerId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ServiceId = table.Column<string>(type: "text", nullable: true),
                    AuditCreatedAt = table.Column<DateTime>(name: "Audit_CreatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 281, DateTimeKind.Utc).AddTicks(8438)),
                    AuditUpdatedAt = table.Column<DateTime>(name: "Audit_UpdatedAt", type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 4, 15, 16, 35, 32, 282, DateTimeKind.Utc).AddTicks(1080)),
                    AuditCreatedBy = table.Column<string>(name: "Audit_CreatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditUpdatedBy = table.Column<string>(name: "Audit_UpdatedBy", type: "text", nullable: true, defaultValue: "admin"),
                    AuditStatus = table.Column<string>(name: "Audit_Status", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faqs_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faqs_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faqs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => new { x.PrescriptionId, x.Id });
                    table.ForeignKey(
                        name: "FK_Drug_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionnaireId",
                table: "Answers",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_AnswerId",
                table: "Faqs",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_QuestionId",
                table: "Faqs",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_ServiceId",
                table: "Faqs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionQuestion_QuestionsId",
                table: "OptionQuestion",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ReviewId",
                table: "Prescriptions",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_PaymentId",
                table: "Questionnaires",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_ServiceId",
                table: "Questionnaires",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ServiceId",
                table: "Questions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ConsultationId",
                table: "Reviews",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_QuestionnaireId",
                table: "Reviews",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionMedium_SessionId",
                table: "SessionMedium",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocsIssues");

            migrationBuilder.DropTable(
                name: "DocsNotifications");

            migrationBuilder.DropTable(
                name: "DocsOutbox");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "OptionQuestion");

            migrationBuilder.DropTable(
                name: "SessionMedium");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.DropTable(
                name: "DocsPayments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ServiceCategories");
        }
    }
}

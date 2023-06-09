﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phoenix.Modules.Pharma.Data;

#nullable disable

namespace Phoenix.Modules.Pharma.Data.Migrations
{
    [DbContext(typeof(PharmaDbContext))]
    partial class PharmaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DrugOrder", b =>
                {
                    b.Property<string>("DrugsId")
                        .HasColumnType("text");

                    b.Property<string>("OrdersId")
                        .HasColumnType("text");

                    b.HasKey("DrugsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("DrugOrder");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Drugs.Drug", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("GenericName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Issues.PharmaIssue", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("PharmaIssues", (string)null);
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Notifications.PharmaNotification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ReadAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PharmaNotifications", (string)null);
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Orders.DispatchInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CollectedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CourierId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DeliveredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCollected")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("boolean");

                    b.Property<string>("PickupCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DispatchInfos");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Orders.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DispatchInfoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("PaymentId")
                        .HasColumnType("text");

                    b.Property<string>("ProcessInfoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReviewId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DispatchInfoId");

                    b.HasIndex("ProcessInfoId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Orders.ProcessInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("AcceptedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FulfilledAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsFulfilled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("boolean");

                    b.Property<string>("PharmaId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ProcessInfos");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Payments.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("PharmaPayments", (string)null);
                });

            modelBuilder.Entity("Phoenix.Shared.Persistence.BoxMessages.InboxMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOccurred")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateProcessed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Error")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PharmaInbox");
                });

            modelBuilder.Entity("Phoenix.Shared.Persistence.BoxMessages.OutboxMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOccurred")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateProcessed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Error")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PharmaOutbox");
                });

            modelBuilder.Entity("DrugOrder", b =>
                {
                    b.HasOne("Phoenix.Modules.Pharma.Data.Drugs.Drug", null)
                        .WithMany()
                        .HasForeignKey("DrugsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Modules.Pharma.Data.Orders.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Drugs.Drug", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("DrugId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 405, DateTimeKind.Utc).AddTicks(2097));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 405, DateTimeKind.Utc).AddTicks(3012));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("DrugId");

                            b1.ToTable("Drugs");

                            b1.WithOwner()
                                .HasForeignKey("DrugId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Issues.PharmaIssue", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("PharmaIssueId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 412, DateTimeKind.Utc).AddTicks(5863));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 412, DateTimeKind.Utc).AddTicks(6676));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("PharmaIssueId");

                            b1.ToTable("PharmaIssues");

                            b1.WithOwner()
                                .HasForeignKey("PharmaIssueId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Notifications.PharmaNotification", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("PharmaNotificationId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 416, DateTimeKind.Utc).AddTicks(6922));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 416, DateTimeKind.Utc).AddTicks(7788));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("PharmaNotificationId");

                            b1.ToTable("PharmaNotifications");

                            b1.WithOwner()
                                .HasForeignKey("PharmaNotificationId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Orders.DispatchInfo", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("DispatchInfoId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 422, DateTimeKind.Utc).AddTicks(3699));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 422, DateTimeKind.Utc).AddTicks(4656));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("DispatchInfoId");

                            b1.ToTable("DispatchInfos");

                            b1.WithOwner()
                                .HasForeignKey("DispatchInfoId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Orders.Order", b =>
                {
                    b.HasOne("Phoenix.Modules.Pharma.Data.Orders.DispatchInfo", "DispatchInfo")
                        .WithMany()
                        .HasForeignKey("DispatchInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Modules.Pharma.Data.Orders.ProcessInfo", "ProcessInfo")
                        .WithMany()
                        .HasForeignKey("ProcessInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 428, DateTimeKind.Utc).AddTicks(383));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 428, DateTimeKind.Utc).AddTicks(1459));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Audit");

                    b.Navigation("DispatchInfo");

                    b.Navigation("ProcessInfo");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Orders.ProcessInfo", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("ProcessInfoId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 432, DateTimeKind.Utc).AddTicks(9152));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 433, DateTimeKind.Utc).AddTicks(223));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("ProcessInfoId");

                            b1.ToTable("ProcessInfos");

                            b1.WithOwner()
                                .HasForeignKey("ProcessInfoId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Pharma.Data.Payments.Payment", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("PaymentId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 437, DateTimeKind.Utc).AddTicks(3201));

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 25, 28, 437, DateTimeKind.Utc).AddTicks(4143));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("PaymentId");

                            b1.ToTable("PharmaPayments");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.Navigation("Audit");
                });
#pragma warning restore 612, 618
        }
    }
}

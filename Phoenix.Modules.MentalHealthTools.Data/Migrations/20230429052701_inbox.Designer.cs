﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phoenix.Modules.MentalHealthTools.Data;

#nullable disable

namespace Phoenix.Modules.MentalHealthTools.Data.Migrations
{
    [DbContext(typeof(MhToolsDbContext))]
    [Migration("20230429052701_inbox")]
    partial class inbox
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.QuoteCategory.QuoteCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.QuoteSubCategory.QuoteSubCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar");

                    b.Property<string>("QuoteCategoryId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuoteCategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.Quotes.Quotes", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Author")
                        .HasMaxLength(70)
                        .HasColumnType("varchar");

                    b.Property<string>("Quote")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.UserQuoteFavorites.UserQuoteFavorites", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("QuoteId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("QuoteId");

                    b.ToTable("UserQuoteFavorites");
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

                    b.ToTable("MHToolsInbox");
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

                    b.ToTable("MHToolsOutbox");
                });

            modelBuilder.Entity("QuoteSubCategoryQuotes", b =>
                {
                    b.Property<string>("QuoteSubCategoriesId")
                        .HasColumnType("text");

                    b.Property<string>("QuotesId")
                        .HasColumnType("text");

                    b.HasKey("QuoteSubCategoriesId", "QuotesId");

                    b.HasIndex("QuotesId");

                    b.ToTable("QuoteSubCategoryQuotes");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.QuoteCategory.QuoteCategory", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("QuoteCategoryId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 795, DateTimeKind.Utc).AddTicks(407));

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
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 795, DateTimeKind.Utc).AddTicks(1039));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("QuoteCategoryId");

                            b1.ToTable("Categories");

                            b1.WithOwner()
                                .HasForeignKey("QuoteCategoryId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.QuoteSubCategory.QuoteSubCategory", b =>
                {
                    b.HasOne("Phoenix.Modules.MentalHealthTools.Data.QuoteCategory.QuoteCategory", "QuoteCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("QuoteCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("QuoteSubCategoryId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 808, DateTimeKind.Utc).AddTicks(9990));

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
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 809, DateTimeKind.Utc).AddTicks(794));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("QuoteSubCategoryId");

                            b1.ToTable("SubCategories");

                            b1.WithOwner()
                                .HasForeignKey("QuoteSubCategoryId");
                        });

                    b.Navigation("Audit");

                    b.Navigation("QuoteCategory");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.Quotes.Quotes", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("QuotesId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 803, DateTimeKind.Utc).AddTicks(8636));

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
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 803, DateTimeKind.Utc).AddTicks(9425));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("QuotesId");

                            b1.ToTable("Quotes");

                            b1.WithOwner()
                                .HasForeignKey("QuotesId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.UserQuoteFavorites.UserQuoteFavorites", b =>
                {
                    b.HasOne("Phoenix.Modules.MentalHealthTools.Data.Quotes.Quotes", "Quote")
                        .WithMany()
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("UserQuoteFavoritesId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 813, DateTimeKind.Utc).AddTicks(732));

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
                                .HasDefaultValue(new DateTime(2023, 4, 29, 5, 27, 0, 813, DateTimeKind.Utc).AddTicks(1548));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("UserQuoteFavoritesId");

                            b1.ToTable("UserQuoteFavorites");

                            b1.WithOwner()
                                .HasForeignKey("UserQuoteFavoritesId");
                        });

                    b.Navigation("Audit");

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("QuoteSubCategoryQuotes", b =>
                {
                    b.HasOne("Phoenix.Modules.MentalHealthTools.Data.QuoteSubCategory.QuoteSubCategory", null)
                        .WithMany()
                        .HasForeignKey("QuoteSubCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Modules.MentalHealthTools.Data.Quotes.Quotes", null)
                        .WithMany()
                        .HasForeignKey("QuotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Phoenix.Modules.MentalHealthTools.Data.QuoteCategory.QuoteCategory", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}

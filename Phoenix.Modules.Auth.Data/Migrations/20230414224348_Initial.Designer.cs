﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phoenix.Modules.Auth.Data.DataContext;

#nullable disable

namespace Phoenix.Modules.Auth.Data.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20230414224348_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Counsellor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Counsellors");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Courier", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPhoneVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("Photo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Courier");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPhoneVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Pharmacy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPhoneVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Phoenix.Shared.Persistence.Outbox.OutboxMessage", b =>
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

                    b.ToTable("AuthOutbox");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Admin", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("AdminId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(4320));

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
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(5285));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("AdminId");

                            b1.ToTable("Admins");

                            b1.WithOwner()
                                .HasForeignKey("AdminId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Counsellor", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("CounsellorId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(4553));

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
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(6694));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("CounsellorId");

                            b1.ToTable("Counsellors");

                            b1.WithOwner()
                                .HasForeignKey("CounsellorId");
                        });

                    b.OwnsOne("Phoenix.Modules.Auth.Data.Rate", "Rate", b1 =>
                        {
                            b1.Property<string>("CounsellorId")
                                .HasColumnType("text");

                            b1.Property<int>("Value")
                                .HasColumnType("integer");

                            b1.HasKey("CounsellorId");

                            b1.ToTable("Counsellors");

                            b1.WithOwner()
                                .HasForeignKey("CounsellorId");
                        });

                    b.Navigation("Audit");

                    b.Navigation("Rate")
                        .IsRequired();
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Courier", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("CourierId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(694));

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
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(3437));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("CourierId");

                            b1.ToTable("Courier");

                            b1.WithOwner()
                                .HasForeignKey("CourierId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Doctor", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("DoctorId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 863, DateTimeKind.Utc).AddTicks(9524));

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
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 864, DateTimeKind.Utc).AddTicks(1570));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Pharmacy", b =>
                {
                    b.OwnsOne("Phoenix.Modules.Auth.Data.Location", "Location", b1 =>
                        {
                            b1.Property<string>("PharmacyId")
                                .HasColumnType("text");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("PharmacyId");

                            b1.ToTable("Pharmacies");

                            b1.WithOwner()
                                .HasForeignKey("PharmacyId");
                        });

                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("PharmacyId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 872, DateTimeKind.Utc).AddTicks(7722));

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
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 873, DateTimeKind.Utc).AddTicks(1353));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("PharmacyId");

                            b1.ToTable("Pharmacies");

                            b1.WithOwner()
                                .HasForeignKey("PharmacyId");
                        });

                    b.Navigation("Audit");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Phoenix.Modules.Auth.Data.Users.User", b =>
                {
                    b.OwnsOne("Phoenix.Shared.Persistence.Audit", "Audit", b1 =>
                        {
                            b1.Property<string>("UserId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(6642));

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
                                .HasDefaultValue(new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(8035));

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnType("text")
                                .HasDefaultValue("admin");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Audit");
                });
#pragma warning restore 612, 618
        }
    }
}

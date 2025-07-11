﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tilmeldingssystem.AppDbcontext;

#nullable disable

namespace Tilmeldingssystem.Migrations
{
    [DbContext(typeof(TilmeldingsDbContext))]
    [Migration("20250707073417_AddMemberActivityRelation")]
    partial class AddMemberActivityRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tilmeldingssystem.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.MemberActivity", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("MemberActivities");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.MemberClub", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "ClubId");

                    b.HasIndex("ClubId");

                    b.ToTable("MemberClubs");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegistrationId"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegistrationId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.MemberActivity", b =>
                {
                    b.HasOne("Tilmeldingssystem.Models.Activity", "Activity")
                        .WithMany("MemberActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tilmeldingssystem.Models.Member", "Member")
                        .WithMany("MemberActivities")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.MemberClub", b =>
                {
                    b.HasOne("Tilmeldingssystem.Models.Club", "Club")
                        .WithMany("MemberClubs")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tilmeldingssystem.Models.Member", "Member")
                        .WithMany("MemberClubs")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Activity", b =>
                {
                    b.Navigation("MemberActivities");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Club", b =>
                {
                    b.Navigation("MemberClubs");
                });

            modelBuilder.Entity("Tilmeldingssystem.Models.Member", b =>
                {
                    b.Navigation("MemberActivities");

                    b.Navigation("MemberClubs");
                });
#pragma warning restore 612, 618
        }
    }
}

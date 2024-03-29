﻿// <auto-generated />
using System;
using Api.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210726115031_intil")]
    partial class intil
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLiaCourse")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<bool>("SearchingForEducator")
                        .HasColumnType("bit");

                    b.Property<bool>("SearchingForGuestLecturer")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Education", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLiaCourses")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastDateForApplication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("RegisterCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchoolId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("SearchingForBoardMembers")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("YHNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegisterCode")
                        .IsUnique();

                    b.HasIndex("SchoolId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.School", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AboutSchool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Courses")
                        .HasColumnType("int");

                    b.Property<string>("Orgnr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Skill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.SkillMatch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("SkillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SkillLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("YearsOfSkill")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("SkillMatches");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.UserGDPR", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("UseMyData")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserGDPRs");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.UserSettings", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("DarkMode")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgreedToTerms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOBifStudent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("OrgNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("VisibleProfile")
                        .HasColumnType("bit")
                        .HasColumnName("Visible Profile");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "admin-c0-aa65-4af8-bd17-00bd9344e575",
                            About = "",
                            AccessFailedCount = 0,
                            Adress = "",
                            AgreedToTerms = "",
                            City = "",
                            CompanyName = "",
                            ConcurrencyStamp = "a7c96345-865b-4dc5-9e5f-0cc800200fc2",
                            DOBifStudent = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@core.api",
                            EmailConfirmed = true,
                            FirstName = "",
                            Gender = "",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@CORE.API",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEBJlflQX9m2+/KTcjNEVJHoAnz8CDUeEYUOo2xuViX1CFN8HxtJcQmCzr9QFpr2cQA==",
                            PhoneNumberConfirmed = false,
                            PostalCode = "",
                            ProfileImageUrl = "",
                            SecurityStamp = "daf84d65-f8c4-44b1-bead-db867e31e780",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            VisibleProfile = false
                        });
                });

            modelBuilder.Entity("Api.Data.Entities.EducationStudent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EducationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.HasIndex("UserId");

                    b.ToTable("EducationStudent");
                });

            modelBuilder.Entity("Api.Data.Entities.MatchManager", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AcceptedJob")
                        .HasColumnType("bit");

                    b.Property<bool>("AcceptedLIA")
                        .HasColumnType("bit");

                    b.Property<bool>("DeclinedJob")
                        .HasColumnType("bit");

                    b.Property<bool>("DeclinedLIA")
                        .HasColumnType("bit");

                    b.Property<string>("MatchedSearchProfileId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SearchProfileId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MatchManager");
                });

            modelBuilder.Entity("Api.Data.Entities.SearchProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktiv")
                        .HasColumnType("bit");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Employment")
                        .HasColumnType("bit");

                    b.Property<bool>("LIA")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SearchProfiles");
                });

            modelBuilder.Entity("Api.Data.Entities.SearchProfileSkillMatch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SearchProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SkillId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SearchProfileId");

                    b.HasIndex("SkillId");

                    b.ToTable("SearchProfileSkillMatches");
                });

            modelBuilder.Entity("Api.Data.StudentSearchProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreeTextDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LookingForEmploymentAfterExam")
                        .HasColumnType("bit");

                    b.Property<bool>("MakeProfileSearchable")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ViewMyGradsFromOrganizers")
                        .HasColumnType("bit");

                    b.Property<int>("YearsOfExprienceInCompany")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StudentSearchProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "root-0c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "93fb74e5-eb23-472b-a954-4e9b902b4d8e",
                            Name = "root",
                            NormalizedName = "ROOT"
                        },
                        new
                        {
                            Id = "user-2c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "80079f38-e089-44c4-9584-dbef778c9f54",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "comp-2c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "6f4a4ae1-73b9-4eb2-aee5-dc31bb228f33",
                            Name = "company",
                            NormalizedName = "COMPANY"
                        },
                        new
                        {
                            Id = "orga-2c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "2fe9af13-acdb-403e-92a3-c09f28008fe1",
                            Name = "organizer",
                            NormalizedName = "ORGANIZER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "admin-c0-aa65-4af8-bd17-00bd9344e575",
                            RoleId = "root-0c0-aa65-4af8-bd17-00bd9344e575"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Course", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.Entities.Education", "Education")
                        .WithMany("Courses")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Education", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.Entities.School", "School")
                        .WithMany("Educations")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.School", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany("Schools")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.SkillMatch", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.Entities.Skill", "Skill")
                        .WithMany("skillMatches")
                        .HasForeignKey("SkillId");

                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany("SkillMatches")
                        .HasForeignKey("UserId");

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.UserGDPR", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.UserSettings", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Data.Entities.EducationStudent", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.Entities.Education", "Education")
                        .WithMany("EducationStudent")
                        .HasForeignKey("EducationId");

                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany("EducationStudent")
                        .HasForeignKey("UserId");

                    b.Navigation("Education");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Data.Entities.MatchManager", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany("MatchManagers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Data.Entities.SearchProfile", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany("SearchProfiles")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Data.Entities.SearchProfileSkillMatch", b =>
                {
                    b.HasOne("Api.Data.Entities.SearchProfile", "SearchProfile")
                        .WithMany("Skills")
                        .HasForeignKey("SearchProfileId");

                    b.HasOne("Api.Areas.Identity.Data.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.Navigation("SearchProfile");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Api.Data.StudentSearchProfile", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", "User")
                        .WithMany("StudentSearchProfiles")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Api.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Education", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("EducationStudent");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.School", b =>
                {
                    b.Navigation("Educations");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.Entities.Skill", b =>
                {
                    b.Navigation("skillMatches");
                });

            modelBuilder.Entity("Api.Areas.Identity.Data.User", b =>
                {
                    b.Navigation("EducationStudent");

                    b.Navigation("MatchManagers");

                    b.Navigation("Schools");

                    b.Navigation("SearchProfiles");

                    b.Navigation("SkillMatches");

                    b.Navigation("StudentSearchProfiles");
                });

            modelBuilder.Entity("Api.Data.Entities.SearchProfile", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}

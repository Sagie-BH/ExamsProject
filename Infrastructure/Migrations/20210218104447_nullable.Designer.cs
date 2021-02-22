﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ExamsAppDbContext))]
    [Migration("20210218104447_nullable")]
    partial class nullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Entities.FinishedExams", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<long?>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<double>("Grade")
                        .HasPrecision(3, 2)
                        .HasColumnType("float(3)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("FinishedExams");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.AnswerOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRightAnswer")
                        .HasColumnType("bit");

                    b.Property<long?>("QuestionObjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionObjectId");

                    b.ToTable("AnswerOption");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.AppExam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExamSubjectId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<double?>("SuccessRate")
                        .HasPrecision(3, 2)
                        .HasColumnType("float(3)");

                    b.Property<TimeSpan?>("TestTimeLimit")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamSubjectId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.QuestionObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AppExamId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("QuestionCompleted")
                        .HasColumnType("bit");

                    b.Property<long?>("QuestionSubjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("QuestionTimeLimit")
                        .HasColumnType("time");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("SuccessRate")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppExamId");

                    b.HasIndex("QuestionSubjectId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.Subject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Domain.Entities.Relational.ClassRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("ClassTeacherId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SubjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassTeacherId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<double>("AvrageGrade")
                        .HasPrecision(3, 2)
                        .HasColumnType("float(3)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ClassRoomId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<long?>("PersonalTeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("PersonalTeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Domain.Models.ExamImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AppExamId")
                        .HasColumnType("bigint");

                    b.Property<string>("Desctiption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppExamId");

                    b.ToTable("ExamImage");
                });

            modelBuilder.Entity("Domain.Models.ExamText", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AppExamId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppExamId");

                    b.ToTable("ExamText");
                });

            modelBuilder.Entity("Domain.Models.UserNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Notification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("UserNotification");
                });

            modelBuilder.Entity("Infrastructure.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("AspNetUsers");
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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entities.FinishedExams", b =>
                {
                    b.HasOne("Domain.Entities.ObjectEntities.AppExam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.HasOne("Domain.Entities.UserEntities.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.AnswerOption", b =>
                {
                    b.HasOne("Domain.Entities.ObjectEntities.QuestionObject", null)
                        .WithMany("AnswerOptions")
                        .HasForeignKey("QuestionObjectId");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.AppExam", b =>
                {
                    b.HasOne("Domain.Entities.ObjectEntities.Subject", "ExamSubject")
                        .WithMany()
                        .HasForeignKey("ExamSubjectId");

                    b.Navigation("ExamSubject");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.QuestionObject", b =>
                {
                    b.HasOne("Domain.Entities.ObjectEntities.AppExam", null)
                        .WithMany("Questions")
                        .HasForeignKey("AppExamId");

                    b.HasOne("Domain.Entities.ObjectEntities.Subject", "QuestionSubject")
                        .WithMany()
                        .HasForeignKey("QuestionSubjectId");

                    b.Navigation("QuestionSubject");
                });

            modelBuilder.Entity("Domain.Entities.Relational.ClassRoom", b =>
                {
                    b.HasOne("Domain.Entities.UserEntities.Teacher", "ClassTeacher")
                        .WithMany("MyClasses")
                        .HasForeignKey("ClassTeacherId");

                    b.HasOne("Domain.Entities.ObjectEntities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassTeacher");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.Student", b =>
                {
                    b.HasOne("Domain.Entities.Relational.ClassRoom", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId");

                    b.HasOne("Domain.Entities.UserEntities.Teacher", "PersonalTeacher")
                        .WithMany()
                        .HasForeignKey("PersonalTeacherId");

                    b.Navigation("PersonalTeacher");
                });

            modelBuilder.Entity("Domain.Models.ExamImage", b =>
                {
                    b.HasOne("Domain.Entities.ObjectEntities.AppExam", null)
                        .WithMany("ExamImages")
                        .HasForeignKey("AppExamId");
                });

            modelBuilder.Entity("Domain.Models.ExamText", b =>
                {
                    b.HasOne("Domain.Entities.ObjectEntities.AppExam", null)
                        .WithMany("ExamText")
                        .HasForeignKey("AppExamId");
                });

            modelBuilder.Entity("Domain.Models.UserNotification", b =>
                {
                    b.HasOne("Domain.Entities.UserEntities.Student", null)
                        .WithMany("Notifications")
                        .HasForeignKey("StudentId");

                    b.HasOne("Domain.Entities.UserEntities.Teacher", null)
                        .WithMany("Notifications")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Infrastructure.Models.AppUser", b =>
                {
                    b.HasOne("Domain.Entities.UserEntities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Domain.Entities.UserEntities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
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
                    b.HasOne("Infrastructure.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Infrastructure.Models.AppUser", null)
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

                    b.HasOne("Infrastructure.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Infrastructure.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.AppExam", b =>
                {
                    b.Navigation("ExamImages");

                    b.Navigation("ExamText");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Domain.Entities.ObjectEntities.QuestionObject", b =>
                {
                    b.Navigation("AnswerOptions");
                });

            modelBuilder.Entity("Domain.Entities.Relational.ClassRoom", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.Student", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.Teacher", b =>
                {
                    b.Navigation("MyClasses");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
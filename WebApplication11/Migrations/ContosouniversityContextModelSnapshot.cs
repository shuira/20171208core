﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication11.Models;

namespace WebApplication11.Migrations
{
    [DbContext(typeof(ContosouniversityContext))]
    partial class ContosouniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication11.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CourseID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepartmentID")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CourseId");

                    b.HasIndex("DepartmentId")
                        .HasName("IX_DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("WebApplication11.Models.CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnName("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnName("InstructorID")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "InstructorId")
                        .HasName("PK_dbo.CourseInstructor");

                    b.HasIndex("CourseId")
                        .HasName("IX_CourseID");

                    b.HasIndex("InstructorId")
                        .HasName("IX_InstructorID");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("WebApplication11.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepartmentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorId")
                        .HasColumnName("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("DepartmentId");

                    b.HasIndex("InstructorId")
                        .HasName("IX_InstructorID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WebApplication11.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EnrollmentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnName("CourseID")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnName("StudentID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId")
                        .HasName("IX_CourseID");

                    b.HasIndex("StudentId")
                        .HasName("IX_StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("WebApplication11.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnName("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("InstructorId")
                        .HasName("PK_dbo.OfficeAssignment");

                    b.HasIndex("InstructorId")
                        .HasName("IX_InstructorID");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("WebApplication11.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(128)")
                        .HasDefaultValueSql("('Instructor')")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("WebApplication11.Models.Course", b =>
                {
                    b.HasOne("WebApplication11.Models.Department", "Department")
                        .WithMany("Course")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_dbo.Course_dbo.Department_DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication11.Models.CourseInstructor", b =>
                {
                    b.HasOne("WebApplication11.Models.Course", "Course")
                        .WithMany("CourseInstructor")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_dbo.CourseInstructor_dbo.Course_CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication11.Models.Person", "Instructor")
                        .WithMany("CourseInstructor")
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_dbo.CourseInstructor_dbo.Instructor_InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication11.Models.Department", b =>
                {
                    b.HasOne("WebApplication11.Models.Person", "Instructor")
                        .WithMany("Department")
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_dbo.Department_dbo.Instructor_InstructorID");
                });

            modelBuilder.Entity("WebApplication11.Models.Enrollment", b =>
                {
                    b.HasOne("WebApplication11.Models.Course", "Course")
                        .WithMany("Enrollment")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Course_CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication11.Models.Person", "Student")
                        .WithMany("Enrollment")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Person_StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication11.Models.OfficeAssignment", b =>
                {
                    b.HasOne("WebApplication11.Models.Person", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("WebApplication11.Models.OfficeAssignment", "InstructorId")
                        .HasConstraintName("FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

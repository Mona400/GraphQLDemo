﻿// <auto-generated />
using System;
using GraphQlDemo.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQlDemo.API.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraphQlDemo.API.DTO.CourseAndStudentDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseAndStudents", (string)null);
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.CourseDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstractorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstractorId");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.InstructorDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Instractors", (string)null);
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.StudentDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.CourseAndStudentDTO", b =>
                {
                    b.HasOne("GraphQlDemo.API.DTO.CourseDTO", "Course")
                        .WithMany("CourseAndStudentDTO")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQlDemo.API.DTO.StudentDTO", "Student")
                        .WithMany("CourseAndStudentDTO")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.CourseDTO", b =>
                {
                    b.HasOne("GraphQlDemo.API.DTO.InstructorDTO", "Instractor")
                        .WithMany("Courses")
                        .HasForeignKey("InstractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instractor");
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.CourseDTO", b =>
                {
                    b.Navigation("CourseAndStudentDTO");
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.InstructorDTO", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("GraphQlDemo.API.DTO.StudentDTO", b =>
                {
                    b.Navigation("CourseAndStudentDTO");
                });
#pragma warning restore 612, 618
        }
    }
}

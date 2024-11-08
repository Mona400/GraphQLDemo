using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using GraphQlDemo.API.Schema;
using GraphQlDemo.API.DTO;

namespace GraphQlDemo.API.Services
{
    public class SchoolDbContext : DbContext
    {

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<InstructorDTO> Instractors { get; set; }
        public DbSet<CourseDTO> Courses { get; set; }
        public DbSet<StudentDTO> Students { get; set; }
        public DbSet<CourseAndStudentDTO> CourseAndStudents { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Platform>()
        //     .HasMany(p => p.Commands)
        //     .WithOne(c => c.Platform)
        //     .HasForeignKey(c => c.PlatformId);


        //    modelBuilder
        //        .Entity<Command>()
        //        .HasOne(x => x.Platform)
        //        .WithMany(x => x.Commands)
        //        .HasForeignKey(x => x.PlatformId)

        //        ;
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public class FinalProjectDbContext : DbContext
{
    private readonly string _connectionString;

    public FinalProjectDbContext()
    {
        _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=CSharpB16;User ID=csharpb16; Password=123456;TrustServerCertificate=True;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //---------------------------------
        // Seed initial admin to User table
        //---------------------------------
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 2997,
                Username = "admin",
                Password = "12345",
                UserType = "Admin"
            }
        );

        //----------------------------------
        //fluent api for Class Subject table
        //----------------------------------
        modelBuilder.Entity<ClassSubject>()
            .HasKey(cs => new { cs.ClassId, cs.SubjectId });

        modelBuilder.Entity<ClassSubject>()
            .HasOne(cs => cs.ClassS)
            .WithMany(c => c.ClassSubjects)
            .HasForeignKey(cs => cs.ClassId);

        modelBuilder.Entity<ClassSubject>()
            .HasOne(cs => cs.Subject)
            .WithMany(s => s.ClassSubjects)
            .HasForeignKey(cs => cs.SubjectId);

        //------------------------------------------
        //fluent api for Class Subject Teacher table
        //------------------------------------------
        modelBuilder.Entity<ClassSubjectTeacher>()
        .HasKey(cst => new { cst.ClassId, cst.SubjectId, cst.TeacherId });

        modelBuilder.Entity<ClassSubjectTeacher>()
            .HasOne(cst => cst.ClassS)
            .WithMany(cs => cs.ClassSubjectTeachers)
            .HasForeignKey(cst => cst.ClassId);

        modelBuilder.Entity<ClassSubjectTeacher>()
            .HasOne(cst => cst.Subject)
            .WithMany(s => s.ClassSubjectTeachers)
            .HasForeignKey(cst => cst.SubjectId);

        modelBuilder.Entity<ClassSubjectTeacher>()
            .HasOne(cst => cst.Teacher)
            .WithMany(t => t.ClassSubjectTeachers)
            .HasForeignKey(cst => cst.TeacherId);

        //--------------------------------------------------
        //fluent api for creating Student table 
        //while making one to many relation with class table
        //--------------------------------------------------

        modelBuilder.Entity<Student>()
            .HasOne(s => s.ClassS)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassId);



        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<ClassS> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ClassSubject> ClassSubjects {  get; set; }
    public DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades {  get; set; }



}

namespace Students.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    
    using Models;
    using Models.Enum;
    
    namespace WebAPIInMemoryDB.Models
    {
        public class StudentDBContext : DbContext
        {
            #region Fields

            public DbSet<Student> Students { get; set; }

            #endregion Fields

            #region Constructor

            public StudentDBContext(DbContextOptions<StudentDBContext> options)
                : base(options)
            {
                LoadInitialStudents();
            }

            #endregion Constructor

            #region Methods
           
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //modelBuilder.Entity<Student>()
                //    .Property(x => x.Id)
                //    .ValueGeneratedOnAdd();
            }

            public void LoadInitialStudents()
            {
                List<Student> studentList = new List<Student>();

                studentList.Add(new Student(id: 1, "Test Student 1", GenderType.Male, DateTime.Parse("2001-12-15")));
                studentList.Add(new Student(id: 2, "Test Student 2", GenderType.Female, DateTime.Parse("2002-11-15")));
                studentList.Add(new Student(id: 3, "Test Student 3", GenderType.Female, DateTime.Parse("2002-01-13")));

                foreach (var student in studentList.Where(student => !this.Students.Any(x => x.Id == student.Id)))
                {
                    this.Students.Add(entity: student);

                    this.SaveChanges();
                }

                this.SaveChanges();
            }

            #endregion Methods
        }
    }
}

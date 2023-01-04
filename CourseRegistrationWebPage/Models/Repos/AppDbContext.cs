using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationWebPage.Models.Repos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op) { }

        public DbSet<Student> Students { get; set;}
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 100, First_Name = "Harry", Last_Name = "Potter", Email = "H.Potter@gmail.com", Phone = "123-456-7899", Course_ID = 2 },
                new Student { ID = 101, First_Name = "Ron", Last_Name = "Weasley", Email = "R.Weasley@gmail.com", Phone = "987-654-3211", Course_ID = 3 },
                new Student { ID = 102, First_Name = "Hermione", Last_Name = "Granger", Email = "H.Granger@gmail.com", Phone = "963-852-7411", Course_ID = 2 },
                new Student { ID = 103, First_Name = "Draco", Last_Name = "Malfoy", Email = "D.Malfoy@gmail.com", Phone = "741-852-9633", Course_ID = 1 },
                new Student { ID = 104, First_Name = "Neville", Last_Name = "Longbottom", Email = "N.Longbottom@gmail.com", Phone = "852-963-7532", Course_ID = 4 }
                );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { ID = 10, First_Name = "Severus", Last_Name = "Snape", Email = "S.Snape@gmail.com", Course_ID = 2 },
                new Instructor { ID = 11, First_Name = "Remus", Last_Name = "Lupin", Email = "L.Lupin@gmail.com", Course_ID = 1 },
                new Instructor { ID = 12, First_Name = "Rubeus", Last_Name = "Hagrid", Email = "R.Hagrid@gmail.com", Course_ID = 3 },
                new Instructor { ID = 13, First_Name = "Minerva", Last_Name = "McGonagall", Email = "M.McGonagall@gmail.com", Course_ID = 4 }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Course_Number = "T0504", Course_Name = "Dark Arts Defense", Description = "Students will learn how to defend themselves from dark magic" },
                new Course { ID = 2, Course_Number = "T0506", Course_Name = "Potions", Description = "Students will learn how to create potions" },
                new Course { ID = 3, Course_Number = "T0509", Course_Name = "Animal Care", Description = "Students will learn how to care for magic animals" },
                new Course { ID = 4, Course_Number = "T0510", Course_Name = "Transfiguration", Description = "Students will learn how to transform themselves" },
                new Course { ID = 5, Course_Number = "T0512", Course_Name = "Herbology", Description = "Students will study the medical properties of herbs" }
                );
        }

    }
}

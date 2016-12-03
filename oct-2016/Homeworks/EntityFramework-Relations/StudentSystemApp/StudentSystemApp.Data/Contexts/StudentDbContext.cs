namespace StudentSystemApp.Data.Contexts
{
    using System.Data.Entity;

    using Models;

    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
            : base("name=StudentDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentDbContext>());
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<License> Licenses { get; set; }
    }
}
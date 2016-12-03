using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StudentSystemApp.Services.Enums;

namespace StudentSystemApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Contexts;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "StudentDbContext";
        }

        protected override void Seed(StudentDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
            this.SeedResources(context);
            this.SeedHomeworks(context);
            this.SeedLicenses(context);
        }

        private void SeedCourses(StudentDbContext context)
        {
            context.Courses.AddOrUpdate(x => x.Id,
                    new Course()
                    {
                        Id = 1,
                        Price = 0,
                        Name = "Programming Basics",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                    },
                    new Course()
                    {
                        Id = 2,
                        Price = 200,
                        Name = "Advanced C#",
                        StartDate = DateTime.Now.AddMonths(2),
                        EndDate = DateTime.Now.AddMonths(4),
                    },
                    new Course()
                    {
                        Id = 3,
                        Price = 280,
                        Name = "Database Basics - MS SQL Server",
                        StartDate = DateTime.Now.AddMonths(4),
                        EndDate = DateTime.Now.AddMonths(6),
                    }
                );

            context.SaveChanges();
        }

        private void SeedStudents(StudentDbContext context)
        {
            context.Students.AddOrUpdate(x => x.Id, 
                    new Student()
                    {
                        Id = 1,
                        Name = "Pete",
                        RegistrationDate = DateTime.Now.AddMonths(-10),
                    },
                    new Student()
                    {
                        Id = 2,
                        Name = "John",
                        RegistrationDate = DateTime.ParseExact("02/02/2014", "dd/mm/yyyy", CultureInfo.CurrentCulture),
                    },
                    new Student()
                    {
                        Id = 3,
                        Name = "Sara",
                        RegistrationDate = DateTime.Today,
                    }
                );

            Student peteStudent = context.Students.Find(1);
            Student johnStudent = context.Students.Find(2);
            Student saraStudent = context.Students.Find(3);

            if (!peteStudent.Courses.Any())
            {
                peteStudent.Courses.Add(context.Courses.Find(1));
            }

            if (!johnStudent.Courses.Any())
            {
                johnStudent.Courses.Add(context.Courses.Find(1));
                johnStudent.Courses.Add(context.Courses.Find(2));
            }

            if (!saraStudent.Courses.Any())
            {
                saraStudent.Courses.Add(context.Courses.Find(1));
                saraStudent.Courses.Add(context.Courses.Find(2));
                saraStudent.Courses.Add(context.Courses.Find(3));
            }

            context.SaveChanges();
        }

        private void SeedResources(StudentDbContext context)
        {
            context.Resources.AddOrUpdate(r => r.Id,
                    new Resource()
                    {
                        Id = 1,
                        Name = "Design Patterns Explained",
                        ResourceType = ResourceType.Video,
                        Url = "http://designpatterns.com/basics",
                        CourseId = 2,
                    },
                    new Resource()
                    {
                        Id = 2,
                        Name = "Declaring Variables",
                        ResourceType = ResourceType.Presentation,
                        Url = "http://softuni.bg/programming-basics/declaring-variables",
                        CourseId = 1,
                    },
                    new Resource()
                    {
                        Id = 3,
                        Name = "How to use LINQ",
                        ResourceType = ResourceType.Document,
                        Url = "http://asp.net/how-to-use-linq",
                        CourseId = 2,
                    }
                );

            context.SaveChanges();
        }

        private void SeedHomeworks(StudentDbContext context)
        {
            context.Homeworks.AddOrUpdate(x => x.Id, 
                    new Homework()
                    {
                        Id = 1,
                        CourseId = 1,
                        StudentId = 1,
                        Content = "x = 1",
                        ContentType = HomeworkContentType.Application,
                        SubmissionDate = DateTime.Now,
                        Course = context.Courses.Find(1),
                        Student = context.Students.Find(1)
                    },
                    new Homework()
                    {
                        Id = 2,
                        CourseId = 2,
                        StudentId = 2,
                        Content = "homework.zip",
                        ContentType = HomeworkContentType.Zip,
                        SubmissionDate = DateTime.Now,
                        Course = context.Courses.Find(2),
                        Student = context.Students.Find(2)
                    }
                );

            context.SaveChanges();
        }
    }
}

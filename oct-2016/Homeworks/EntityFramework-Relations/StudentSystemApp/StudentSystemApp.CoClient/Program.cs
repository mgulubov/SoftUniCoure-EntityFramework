using System.Collections.Generic;
using System.Data.Entity;
using StudentSystemApp.Models;

namespace StudentSystemApp.CoClient
{
    using System;
    using System.Linq;

    using Data.Contexts;

    public class Program
    {
        public static void Main(string[] args)
        {
            StudentDbContext context = new StudentDbContext();

            //IQueryable<Course> courses = context.Courses;
            //foreach (Course course in courses)
            //{
            //    ICollection<Student> students = course.Students;

            //    foreach (Student student in students)
            //    {
            //        Console.WriteLine(student.Name);
            //    }
            //}

            //IQueryable<Student> students = context.Students;
            //foreach (Student student in students)
            //{
            //    Console.WriteLine(student.Courses.Count);
            //}

            //IQueryable<Homework> homeworks = context.Homeworks;
            //foreach (Homework homework in homeworks)
            //{
            //    Console.WriteLine($"{homework.Course.Name} {homework.Student.Name}");
            //}

            //IQueryable<Resource> resources = context.Resources;
            //foreach (Resource resource in resources)
            //{
            //    Console.WriteLine(resource.Course.Name);
            //}

            IQueryable<License> licenses = context.Licenses;
            Console.WriteLine(licenses.Count());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using University.Models;
using System;
using System.Linq;

namespace University.Data
{
    public static class DbInitializer
    {
        public static void Initializer(UniversityContext context)
        {
            context.Database.Migrate();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2010-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2012-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2013-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2012-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2012-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2011-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2013-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                  new Department { DepartmentName = "English", Budget = 350000, StartDate = DateTime.Parse("2007-09-01") },
                  new Department { DepartmentName = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01") },
                  new Department { DepartmentName = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01") },
                  new Department { DepartmentName = "Economics", Budget = 200000, StartDate = DateTime.Parse("2007-09-01") }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Id=1050, CourseId=1050, Name="Chemistry", Title="Chemistry", Credits=3, DepartmentId=3},
                new Course{Id=4022, CourseId=4022, Name="Microeconomics", Title="Microeconomics", Credits=3, DepartmentId=4},
                new Course{Id=4041, CourseId=4041, Name="Macroeconomics", Title="Macroeconomics", Credits=3, DepartmentId=4},
                new Course{Id=1045, CourseId=1045, Name="Calculus", Title="Calculus", Credits=4, DepartmentId=2},
                new Course{Id=3141, CourseId=3141, Name="Trigonometry", Title="Trigonometry", Credits=4, DepartmentId=2},
                new Course{Id=2021, CourseId=2021, Name="Composition", Title="Composition", Credits=3, DepartmentId=1},
                new Course{Id=2042, CourseId=2042, Name="Literature", Title="Literature", Credits=4, DepartmentId=1}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentId=1,CourseId=1050,Grade=Grade.A},
                new Enrollment{StudentId=1,CourseId=4022,Grade=Grade.C},
                new Enrollment{StudentId=1,CourseId=4041,Grade=Grade.B},
                new Enrollment{StudentId=2,CourseId=1045,Grade=Grade.B},
                new Enrollment{StudentId=2,CourseId=3141,Grade=Grade.F},
                new Enrollment{StudentId=2,CourseId=2021,Grade=Grade.F},
                new Enrollment{StudentId=3,CourseId=1050},
                new Enrollment{StudentId=4,CourseId=1050},
                new Enrollment{StudentId=4,CourseId=4022,Grade=Grade.F},
                new Enrollment{StudentId=5,CourseId=4041,Grade=Grade.C},
                new Enrollment{StudentId=6,CourseId=1045},
                new Enrollment{StudentId=7,CourseId=3141,Grade=Grade.A}
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}

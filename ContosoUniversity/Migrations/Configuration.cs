namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using ContosoUniversity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ContosoUniversity.DAL.SchoolContext";
        }

        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstMidName="����ɭ",LastName="��",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="÷���˹",LastName="��",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="��ͼ��",LastName="��",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="���",LastName="��",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="��",LastName="��",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="�弪",LastName="��",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="����",LastName="��",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="��ŵ",LastName="С",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();



            var courses = new List<Course>
            {
            new Course{CourseID=550,Title="��ѧ",Credits=3,},
            new Course{CourseID=560,Title="΢�۾���ѧ",Credits=3,},
            new Course{CourseID=650,Title="��۾���ѧ",Credits=3,},
            new Course{CourseID=660,Title="΢����ѧ",Credits=4,},
            new Course{CourseID=750,Title="��������ѧ",Credits=4,},
            new Course{CourseID=960,Title="�ϳɻ�ѧ",Credits=3,},
            new Course{CourseID=980,Title="��ѧ",Credits=4,}
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p=>p.Title,s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentID=students.Single(s=>s.FirstMidName=="����").ID,
                    CourseID=courses.Single(s=>s.Title=="΢����ѧ").CourseID,
                    Grade=Grade.A
                },
                new Enrollment
                {
                    StudentID =students.Single(s=>s.FirstMidName=="����").ID,
                    CourseID =courses.Single(s=>s.Title=="��ѧ").CourseID,
                    Grade =Grade.A
                },
            new Enrollment{StudentID=1,CourseID=560,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=550,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=560,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=660,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=750,Grade=Grade.E},
            new Enrollment{StudentID=2,CourseID=960,Grade=Grade.E},
            new Enrollment{StudentID=3,CourseID=980},
            new Enrollment{StudentID=4,CourseID=550,},
            new Enrollment{StudentID=4,CourseID=660,Grade=Grade.E},
            new Enrollment{StudentID=5,CourseID=750,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=660},
            new Enrollment{StudentID=7,CourseID=980,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            foreach(Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                   s => s.Student.ID == e.StudentID && s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

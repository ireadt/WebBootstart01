using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var users = new List<UserDetails>
            {
                new UserDetails {UserName="admin",Password="admin"},
                new UserDetails {UserName="guest",Password="guest"}
            };
            users.ForEach(u => context.UserDbset.Add(u));
            context.SaveChanges();

            //users.ForEach(u=>context





            var students = new List<Student>
            {
           new Student{FirstMidName="卡尔森",LastName="本",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="梅瑞迪斯",LastName="杰",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="阿图罗",LastName="德",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="格蒂",LastName="莱",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="杨",LastName="老",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="佩吉",LastName="廖",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="劳拉",LastName="哈",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="尼诺",LastName="小",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=550,Title="化学",Credits=3,},
            new Course{CourseID=560,Title="微观经济学",Credits=3,},
            new Course{CourseID=650,Title="宏观经济学",Credits=3,},
            new Course{CourseID=660,Title="微积分学",Credits=4,},
            new Course{CourseID=750,Title="解析三角学",Credits=4,},
            new Course{CourseID=960,Title="合成化学",Credits=3,},
            new Course{CourseID=980,Title="文学",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
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
            context.SaveChanges();
        }
    }
}
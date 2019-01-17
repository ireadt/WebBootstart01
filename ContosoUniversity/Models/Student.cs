using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ContosoUniversity.Models
{
    public class Student
    {
        
        public int ID { get; set; }
        [Display(Name = "姓名")]
        public string LastName { get; set; }
        [Display(Name ="用户名")]
        public string FirstMidName { get; set; }
        [Display(Name = "日期")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name ="头像")]
        public string Image { get; set; }


        public string Secret { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistrationWebPage.Models
{
    public class Student
    {
        [DisplayName("Student ID")]
        [Key]
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string First_Name { get; set; }
        [DisplayName("Last Name")]
        public string Last_Name { get; set;  }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DisplayName("Course ID")]
        [ForeignKey("Course")]
        public int? Course_ID { get; set; }
        public Course Course { get; set; }
    }
}

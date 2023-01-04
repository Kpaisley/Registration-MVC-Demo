using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistrationWebPage.Models
{
    public class Course
    {
        [DisplayName("Course ID")]
        [Key]
        public int ID { get; set; }
        [DisplayName("Course Number")]
        public string Course_Number { get; set; }
        [DisplayName("Course Name")]
        public string Course_Name { get; set; }
        public string Description { get; set; }
    }
}

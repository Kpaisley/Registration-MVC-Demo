namespace CourseRegistrationWebPage.Models.Repos
{
    public class MockCourseRepo
    {
        private static int i = 6;
        private readonly MockStudentRepo _studentRepo = new MockStudentRepo();
        private readonly MockInstructorRepo _instructorRepo= new MockInstructorRepo();
        private static List<Course> courses = new List<Course>
        {
            new Course {ID = 1, Course_Number = "T0504", Course_Name = "Dark Arts Defense", Description = "Students will learn how to defend themselves from dark magic"},
            new Course {ID = 2, Course_Number = "T0506", Course_Name = "Potions", Description = "Students will learn how to create potions"},
            new Course {ID = 3, Course_Number = "T0509", Course_Name = "Animal Care", Description = "Students will learn how to care for magic animals"},
            new Course {ID = 4, Course_Number = "T0510", Course_Name = "Transfiguration", Description = "Students will learn how to transform themselves"},
            new Course {ID = 5, Course_Number = "T0512", Course_Name = "Herbology", Description = "Students will study the medical properties of herbs"}
        };

        public IEnumerable<Course> GetAll()
        {
            return courses;
        }

        public void Create(Course newCourse)
        {
            //int newCourseID = courses.Max(x => x.ID) + 1; THIS CRASHES WHEN ALL COURSES ARE DELETED
            newCourse.ID = i++;
            courses.Add(newCourse);
        }

        

        public Course GetByID(int id)
        {
            
            return courses.FirstOrDefault(c => c.ID == id);
        }

        public void Update(int id, Course collection)
        {
            var course = GetByID(id);
            if (course != null)
            {
                course.Course_Name = collection.Course_Name;
                course.Description = collection.Description; 
            }
        }

        public void Delete(int id)
        {

            var courseToDelete = GetByID(id);
            courses.Remove(courseToDelete);

            var students = _studentRepo.GetAll().Where(s => s.Course_ID == id).ToList();
            var instructors = _instructorRepo.GetAll().Where(c => c.Course_ID == id).ToList();
            foreach (var student in students)
            {
                student.Course_ID = null;   
            }
            foreach (var instructor in instructors)
            {
                instructor.Course_ID = null;
            }

        }

        
    }
}

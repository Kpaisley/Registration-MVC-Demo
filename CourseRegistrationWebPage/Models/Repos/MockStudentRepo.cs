using CourseRegistrationWebPage.Models.Repos.Interfaces;

namespace CourseRegistrationWebPage.Models.Repos
{
    public class MockStudentRepo : IStudentRepo
    {
        private static int i = 105;
        private static List<Student> students= new List<Student>
        {
            new Student{ID = 100, First_Name = "Harry", Last_Name = "Potter", Email = "H.Potter@gmail.com", Phone = "123-456-7899", Course_ID = 2},
            new Student{ID = 101, First_Name = "Ron", Last_Name = "Weasley", Email = "R.Weasley@gmail.com", Phone = "987-654-3211", Course_ID = 3},
            new Student{ID = 102, First_Name = "Hermione", Last_Name = "Granger", Email = "H.Granger@gmail.com", Phone = "963-852-7411", Course_ID = 2},
            new Student{ID = 103, First_Name = "Draco", Last_Name = "Malfoy", Email = "D.Malfoy@gmail.com", Phone = "741-852-9633", Course_ID = 1},
            new Student{ID = 104, First_Name = "Neville", Last_Name = "Longbottom", Email = "N.Longbottom@gmail.com", Phone = "852-963-7532", Course_ID = 4}
        };

        

        public IEnumerable<Student> GetAll()
        {
            return students; 
        }

        public void Create(Student newStudent)
        {
            //int newStudentID = students.Max(x => x.ID) + 1; THIS CRASHES WHEN ALL COURSES ARE DELETED
            newStudent.ID = i++;
            students.Add(newStudent);
        }

        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s => s.ID == id);
        }

        public void Update (int id, Student collection)
        {    
            var student = GetByID(id);
            if (student != null)
            {
                student.First_Name = collection.First_Name;
                student.Last_Name = collection.Last_Name;
                student.Email = collection.Email;
                student.Phone = collection.Phone;
                student.Course_ID = collection.Course_ID;
            }
        }

        public void DeleteByID(int id)
        {
            var studentToDelete = GetByID(id);
            students.Remove(studentToDelete);
        }

        
    }
}

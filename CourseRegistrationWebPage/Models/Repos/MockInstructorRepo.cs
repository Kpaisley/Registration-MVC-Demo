using CourseRegistrationWebPage.Models.Repos.Interfaces;

namespace CourseRegistrationWebPage.Models.Repos
{
    public class MockInstructorRepo : IInstructorRepo
    {
        private static int i = 14;
        private static List<Instructor> instructors = new List<Instructor>
        {
            new Instructor {ID = 10, First_Name = "Severus", Last_Name = "Snape", Email = "S.Snape@gmail.com", Course_ID = 2},
            new Instructor {ID = 11, First_Name = "Remus", Last_Name = "Lupin", Email = "L.Lupin@gmail.com", Course_ID = 1},
            new Instructor {ID = 12, First_Name = "Rubeus", Last_Name = "Hagrid", Email = "R.Hagrid@gmail.com", Course_ID = 3},
            new Instructor {ID = 13, First_Name = "Minerva", Last_Name = "McGonagall", Email = "M.McGonagall@gmail.com", Course_ID = 4}
        };
        

        public IEnumerable<Instructor> GetAll()
        {
            return instructors;
        }

        public void Create(Instructor newInstructor)
        {

            //int newInstructorID = instructors.Max(x => x.ID) + 1; THIS CRASHES WHEN ALL COURSES ARE DELETED
            newInstructor.ID = i++;
            instructors.Add(newInstructor);
            

        }

        public void Update(int id, Instructor collection)
        {
            var instructor = GetByID(id);
            if (instructor != null)
            {
                instructor.First_Name = collection.First_Name;
                instructor.Last_Name = collection.Last_Name;
                instructor.Email = collection.Email;
                instructor.Course_ID = collection.Course_ID;
            }
        }

        public Instructor GetByID(int id)
        {
            return instructors.FirstOrDefault(s => s.ID == id);
        }

        public void DeleteByID(int id)
        {
            var instructorToDelete = GetByID(id);
            instructors.Remove(instructorToDelete);
        }
    }
}

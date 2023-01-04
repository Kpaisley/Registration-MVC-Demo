using CourseRegistrationWebPage.Models.Repos.Interfaces;

namespace CourseRegistrationWebPage.Models.Repos.MySqlRepos
{
    public class MySqlStudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        public MySqlStudentRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void Create(Student newStudent)
        {
            if (newStudent == null)
            {
                throw new ArgumentNullException(nameof(newStudent));
            }
            _context.Add(newStudent);
            _context.SaveChanges();

        }

        public void DeleteByID(int id)
        {
            var StudentToDelete = GetByID(id);
            if (StudentToDelete!= null)
            {
                _context.Remove(StudentToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetByID(int id)
        {
            return _context.Students.FirstOrDefault(s => s.ID == id);
        }

        public void Update(int id, Student collection)
        {
            var StudentToUpdate = GetByID(id);
            if (StudentToUpdate!= null)
            {
                StudentToUpdate.First_Name = collection.First_Name;
                StudentToUpdate.Last_Name= collection.Last_Name;
                StudentToUpdate.Email= collection.Email;
                StudentToUpdate.Phone = collection.Phone;
                StudentToUpdate.Course_ID = collection.Course_ID;
                _context.SaveChanges();
            }
        }
    }
}

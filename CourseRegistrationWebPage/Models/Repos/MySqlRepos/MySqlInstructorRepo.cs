using CourseRegistrationWebPage.Models.Repos.Interfaces;

namespace CourseRegistrationWebPage.Models.Repos.MySqlRepos
{
    public class MySqlInstructorRepo : IInstructorRepo
    {
        private readonly AppDbContext _context;
        public MySqlInstructorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Instructor newInstructor)
        {
            if (newInstructor == null)
            {
                throw new ArgumentNullException(nameof(newInstructor));
            }
            _context.Add(newInstructor);
            _context.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var InstructorToDelete = GetByID(id);
            if (InstructorToDelete != null)
            {
                _context.Remove(InstructorToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetByID(int id)
        {
            return _context.Instructors.Where(i => i.ID == id).FirstOrDefault();
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
                _context.SaveChanges();
            }
        }
    }
}

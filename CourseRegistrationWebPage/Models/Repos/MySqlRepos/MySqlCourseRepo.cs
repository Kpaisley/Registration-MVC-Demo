using CourseRegistrationWebPage.Models.Repos.Interfaces;

namespace CourseRegistrationWebPage.Models.Repos.MySqlRepos
{
    public class MySqlCourseRepo : ICourseRepo
    {
        private readonly AppDbContext _context;
        public MySqlCourseRepo(AppDbContext context)
        {
            _context = context;
        }


        public void Create(Course newCourse)
        {
            if (newCourse == null)
            {
                throw new ArgumentNullException(nameof(newCourse));
            }
            _context.Add(newCourse);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var CourseToDelete = _context.Courses.FirstOrDefault(c => c.ID== id);
            var students = _context.Students.Where(s => s.Course_ID == id).ToList();
            var instructors = _context.Instructors.Where(c => c.Course_ID == id).ToList();
            foreach (var student in students)
            {
                student.Course_ID = null;
            }
            foreach (var instructor in instructors)
            {
                instructor.Course_ID = null;
            }
            _context.Remove(CourseToDelete);
            _context.SaveChanges();

            
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetByID(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.ID == id);
        }

        public void Update(int id, Course collection)
        {
            var CourseToUpdate = _context.Courses.FirstOrDefault(c => c.ID== id);
            if (CourseToUpdate != null)
            {
                CourseToUpdate.Course_Name = collection.Course_Name;
                CourseToUpdate.Description= collection.Description;
                _context.SaveChanges();
            }
        }
    }
}

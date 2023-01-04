namespace CourseRegistrationWebPage.Models.Repos.Interfaces
{
    public interface ICourseRepo
    {
        public IEnumerable<Course> GetAll();
        public void Create(Course newCourse);
        public Course GetByID(int id);
        public void Update(int id, Course collection);
        public void Delete(int id);

    }
}

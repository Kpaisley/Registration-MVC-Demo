namespace CourseRegistrationWebPage.Models.Repos.Interfaces
{
    public interface IInstructorRepo
    {
        public IEnumerable<Instructor> GetAll();
        public void Create(Instructor newInstructor);
        public void Update(int id, Instructor collection);
        public Instructor GetByID(int id);
        public void DeleteByID(int id);

    }
}

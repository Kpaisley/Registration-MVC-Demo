using System.Diagnostics.SymbolStore;

namespace CourseRegistrationWebPage.Models.Repos.Interfaces
{
    public interface IStudentRepo
    {
        public IEnumerable<Student> GetAll();
        public void Create(Student newStudent);
        public Student GetByID(int id);
        public void Update(int id, Student collection);
        public void DeleteByID(int id);


    }
}

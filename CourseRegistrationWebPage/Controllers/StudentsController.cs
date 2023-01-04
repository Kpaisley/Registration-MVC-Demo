using CourseRegistrationWebPage.Models;
using CourseRegistrationWebPage.Models.Repos;
using CourseRegistrationWebPage.Models.Repos.Interfaces;
using CourseRegistrationWebPage.Models.Repos.MySqlRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseRegistrationWebPage.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly MockStudentRepo _studentsRepo = new MockStudentRepo();
        //private readonly MockCourseRepo _coursesRepo = new MockCourseRepo();

        private readonly IStudentRepo _studentsRepo;
        private readonly ICourseRepo _coursesRepo;

        public StudentsController(IStudentRepo studentRepo, ICourseRepo coursesRepo)
        {
            _studentsRepo = studentRepo;
            _coursesRepo = coursesRepo;
        }



        // GET: StudentsController
        public ActionResult Index()
        {
            return View(_studentsRepo.GetAll());
        }

        public IEnumerable<string> GetStudentsByCourseID(int id)
        {
           var res = _studentsRepo.GetAll().Where(x => x.Course_ID == id).Select(x => $"{x.First_Name} {x.Last_Name} <br>");
            if (res == null || res.Count() <= 0)
            {
                return new List<string> { "No students found." };
            }
            return res;
        }


        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            var student = _studentsRepo.GetByID(id);
            return View(student);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            ViewBag.Student = new SelectList(_coursesRepo.GetAll(), "ID", "Course_Name");

            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student collection)
        {            
            try
            {
                _studentsRepo.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            var studentToEdit = _studentsRepo.GetByID(id);
            ViewBag.CourseName = new SelectList(_coursesRepo.GetAll(), "ID", "Course_Name");
            return View(studentToEdit);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                _studentsRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var studentToDelete = _studentsRepo.GetByID(id);
            return View(studentToDelete);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _studentsRepo.DeleteByID(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

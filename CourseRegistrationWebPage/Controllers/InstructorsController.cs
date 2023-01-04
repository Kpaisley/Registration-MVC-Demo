using CourseRegistrationWebPage.Models;
using CourseRegistrationWebPage.Models.Repos;
using CourseRegistrationWebPage.Models.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace CourseRegistrationWebPage.Controllers
{
    public class InstructorsController : Controller
    {
        //private readonly MockInstructorRepo _instructorRepo = new MockInstructorRepo();
        //private readonly MockCourseRepo _coursesRepo = new MockCourseRepo();


        private readonly IInstructorRepo _instructorRepo;
        private readonly ICourseRepo _coursesRepo;
        public InstructorsController(IInstructorRepo instructorRepo, ICourseRepo courseRepo)
        {
            _instructorRepo = instructorRepo;
            _coursesRepo = courseRepo;
        }


        // GET: InstructorsController
        public ActionResult Index()
        {
            return View(_instructorRepo.GetAll());
        }

        // GET: InstructorsController/Details/5
        public ActionResult Details(int id)
        {
            var instructor = _instructorRepo.GetByID(id);
           
            return View(instructor);
        }

        // GET: InstructorsController/Create
        public ActionResult Create()
        {
            ViewBag.Courses = new SelectList(_coursesRepo.GetAll(), "ID", "Course_Name");
            return View();
        }

        // POST: InstructorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor collection)
        {
            try
            {
                _instructorRepo.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorsController/Edit/5
        public ActionResult Edit(int id)
        {           
            ViewBag.CourseName = new SelectList(_coursesRepo.GetAll(), "ID", "Course_Name");
            var instructorToEdit = _instructorRepo.GetByID(id);
            return View(instructorToEdit);
        }

        // POST: InstructorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instructor collection)
        {
            try
            {
                _instructorRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorsController/Delete/5
        public ActionResult Delete(int id)
        {
            var instructorToDelete = _instructorRepo.GetByID(id);
            return View(instructorToDelete);
        }

        // POST: InstructorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Instructor collection)
        {
            try
            {
                _instructorRepo.DeleteByID(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

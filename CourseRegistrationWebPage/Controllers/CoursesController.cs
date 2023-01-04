using CourseRegistrationWebPage.Models;
using CourseRegistrationWebPage.Models.Repos;
using CourseRegistrationWebPage.Models.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationWebPage.Controllers
{
    public class CoursesController : Controller
    {
        //private readonly MockCourseRepo _courseRepo = new MockCourseRepo();
        private readonly ICourseRepo _courseRepo;
        public CoursesController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        //GET: CoursesController
        public ActionResult Index()
        {
            return View(_courseRepo.GetAll());
        }

        // GET: CoursesController/Details/5
        public ActionResult Details(int id)
        {
            var course = _courseRepo.GetByID(id);
            return View(course);
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course collection)
        {
            try
            {
                _courseRepo.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            var CourseToEdit = _courseRepo.GetByID(id);
            return View(CourseToEdit);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course collection)
        {
            try
            {
                _courseRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            var CourseToDelete = _courseRepo.GetByID(id);
            return View(CourseToDelete);
        }

        // POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Course collection)
        {
            try
            {
                _courseRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

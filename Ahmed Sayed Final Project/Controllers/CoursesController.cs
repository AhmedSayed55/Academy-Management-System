using Ahmed_Sayed_Final_Project.DbContexts;
using Ahmed_Sayed_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Sayed_Final_Project.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationDbContext _context;
        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult GetCreateView()
        {
            ViewBag.AllProfessors = _context.Professor.ToList();
            return View("Create");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateCourse([Bind("CourseName,CourseCode,Price,Description,ProfessorId")] Course cor)
        {
            if (cor != null && _context.courses.Any(e => e.CourseCode == cor.CourseCode))
            {
                ModelState.AddModelError(string.Empty, "This code Is Registered To Another course");
            }

            if (ModelState.IsValid == true)
            {
                _context.courses.Add(cor);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllProfessors = _context.Professor.ToList();
                return View("create");
            }

          
        }

        //[HttpGet]
        //public ActionResult GetIndexView()
        //{
        //    var courses = _context.courses.ToList();
        //    return View("index",courses);
        //}


        [HttpGet]
        public ActionResult GetIndexView(string? search, int profId, string sortType, string sortOrder)
        {
            var cor = _context.courses.AsQueryable();
            if (search != null)
            {
                cor = cor.Where(e => e.CourseName.Contains(search));
            }

            ViewBag.CurrentSearch = search;

            if (profId != 0)
            {
                cor = cor.Where(e => e.ProfessorId == profId);
            }
            ViewBag.CurrentProfId = profId;
            ViewBag.AllProfessors = _context.Professor;

            if (sortType != null && sortOrder != null)
            {
                if (sortType == "CourseName")
                {
                    if (sortOrder == "asc")
                        cor = cor.OrderBy(e => e.CourseName);
                    else if (sortOrder == "dec")
                        cor = cor.OrderByDescending(e => e.CourseName);
                }
                else if (sortType == "Price")
                {
                    if (sortOrder == "asc")
                        cor = cor.OrderBy(e => e.Price);
                    else if (sortOrder == "dec")
                        cor = cor.OrderByDescending(e => e.Price);
                }
            }

            return View("index", cor.ToList());
        }

        [HttpGet]
        public ActionResult GetDetailsView(int id)
        {
            Course cor = _context.courses.Include(c => c.Professor).FirstOrDefault(c => c.Id == id);
            if (cor == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", cor);
            }
        }

        [HttpGet]
        public ActionResult GetEditView(int id)
        {
            Course cor = _context.courses.FirstOrDefault(e => e.Id == id)!;
            if (cor == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.AllProfessors = _context.Professor.ToList();
                return View("Edit", cor);
            }
        }
        [HttpPost]
        public ActionResult EditCourse([Bind("Id,CourseName,CourseCode,Price,Description,ProfessorId")] Course cor)
        {
            if (cor != null && _context.courses.Any(c => c.CourseCode == cor.CourseCode && c.Id != cor.Id))
            {
                ModelState.AddModelError(string.Empty, "The National Number Is Registered To Another User");
            }
            if (ModelState.IsValid == true)
            {
                _context.courses.Update(cor);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllProfessors = _context.Professor.ToList();
                return View("index");
            }
        }

        [HttpGet]
        public ActionResult GetDeleteView(int id)
        {
            Course cor = _context.courses.Include(c => c.Professor).FirstOrDefault(c => c.Id == id)!;
            if (cor == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", cor);
            }
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteCourse(int id)
        {
            Course cor = _context.courses.FirstOrDefault(e => e.Id == id);
            _context.courses.Remove(cor);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }
    }
}

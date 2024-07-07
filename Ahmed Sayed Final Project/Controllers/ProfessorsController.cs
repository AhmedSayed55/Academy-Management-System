using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ahmed_Sayed_Final_Project.DbContexts;
using Ahmed_Sayed_Final_Project.Models;

namespace Ahmed_Sayed_Final_Project.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professors
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Professor != null ? 
        //                  View(await _context.Professor.ToListAsync()) :
        //                  Problem("Entity set 'ApplicationDbContext.Professor'  is null.");
        //}


        [HttpGet]
        public ActionResult Index(string? search, int profId, string sortType, string sortOrder)
        {
            var prof = _context.Professor.AsQueryable();
            if (search != null)
            {
                prof = prof.Where(e => e.FullName.Contains(search));
            }

            ViewBag.CurrentSearch = search;

           // if (C != 0)
            //{
            //    prof = prof.Where(e => e.ProfessorId == profId);
            //}
            //ViewBag.CurrentProfId = profId;
            //ViewBag.AllProfessors = _context.Professor;

            if (sortType != null && sortOrder != null)
            {
                if (sortType == "FullName")
                {
                    if (sortOrder == "asc")
                        prof = prof.OrderBy(e => e.FullName);
                    else if (sortOrder == "dec")
                        prof = prof.OrderByDescending(e => e.FullName);
                }
                else if (sortType == "Salary")
                {
                    if (sortOrder == "asc")
                        prof = prof.OrderBy(e => e.Salary);
                    else if (sortOrder == "dec")
                        prof = prof.OrderByDescending(e => e.Salary);
                }
            }

            return View("index", prof.ToList());
        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.Include(c=>c.courses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,NationalNumber,Salary,Bonus")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,NationalNumber,Salary,Bonus")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Professor'  is null.");
            }
            var professor = await _context.Professor.FindAsync(id);
            if (professor != null)
            {
                _context.Professor.Remove(professor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
          return (_context.Professor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

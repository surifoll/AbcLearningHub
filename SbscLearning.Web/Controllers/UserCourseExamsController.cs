using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbcLearningHub.Data.DataAccess;
using AbcLearningHub.Data.Entities;

namespace AbcLearningHub.Controllers
{
    public class UserCourseExamsController : Controller
    {
        private readonly AbcLearningHubContext _context;

        public UserCourseExamsController(AbcLearningHubContext context)
        {
            _context = context;
        }

        // GET: UserCourseExams
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserCourseExams.ToListAsync());
        }

        // GET: UserCourseExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourseExam = await _context.UserCourseExams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCourseExam == null)
            {
                return NotFound();
            }

            return View(userCourseExam);
        }

        // GET: UserCourseExams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserCourseExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserCourseId,CourseExamId,DateTaken")] UserCourseExam userCourseExam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCourseExam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCourseExam);
        }

        // GET: UserCourseExams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourseExam = await _context.UserCourseExams.FindAsync(id);
            if (userCourseExam == null)
            {
                return NotFound();
            }
            return View(userCourseExam);
        }

        // POST: UserCourseExams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserCourseId,CourseExamId,DateTaken")] UserCourseExam userCourseExam)
        {
            if (id != userCourseExam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCourseExam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCourseExamExists(userCourseExam.Id))
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
            return View(userCourseExam);
        }

        // GET: UserCourseExams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourseExam = await _context.UserCourseExams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCourseExam == null)
            {
                return NotFound();
            }

            return View(userCourseExam);
        }

        // POST: UserCourseExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userCourseExam = await _context.UserCourseExams.FindAsync(id);
            _context.UserCourseExams.Remove(userCourseExam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCourseExamExists(int id)
        {
            return _context.UserCourseExams.Any(e => e.Id == id);
        }
    }
}

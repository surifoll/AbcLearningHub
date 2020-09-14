using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbcLearningHub.Business.Services;
using AbcLearningHub.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbcLearningHub.Data.DataAccess;
using AbcLearningHub.Data.Entities;

namespace AbcLearningHub.Controllers
{
    public class CourseExamsController : Controller
    {
        private readonly ICourseExamService _context;
        private readonly ICourseService _courseService;

        public CourseExamsController(ICourseExamService context, ICourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }

        // GET: CourseExams
        public async Task<IActionResult> Index()
        {
            var abcLearningHubContext = _context.Get();
            return View(abcLearningHubContext);
        }

        // GET: CourseExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseExam =  _context.Get()
               .FirstOrDefault(m => m.Id == id);
            if (courseExam == null)
            {
                return NotFound();
            }

            return View(courseExam);
        }

        // GET: CourseExams/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_courseService.Get(), "Id", "Name");
            return View();
        }

        // POST: CourseExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,ExamName,Description")] CourseExamModel courseExam)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(courseExam);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_courseService.Get(), "Id", "Name", courseExam.CourseId);
            return View(courseExam);
        }

        // GET: CourseExams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseExam = await _context.Get((int) id);
            if (courseExam == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_courseService.Get(), "Id", "Name", courseExam.CourseId);
            return View(courseExam);
        }

        // POST: CourseExams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,ExamName,Description")] CourseExamModel courseExam)
        {
            if (id != courseExam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(courseExam);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExamExists(courseExam.Id))
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
            ViewData["CourseId"] = new SelectList(_courseService.Get(), "Id", "Name", courseExam.CourseId);
            return View(courseExam);
        }

      
 

        private bool CourseExamExists(int id)
        {
            var courseExam = _context.Get()
                .FirstOrDefault(m => m.Id == id);
            return courseExam != null;
        }
    }
}

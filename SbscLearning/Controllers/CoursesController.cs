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
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;
        private readonly IAuthorService _authorService;

        public CoursesController(ICourseService service, IAuthorService authorService)
        {
            _service = service;
            _authorService = authorService;
        }

        // GET: Courses
        public IActionResult Index()
        {
            var abcLearningHubContext = _service.Get();
            return View(abcLearningHubContext.ToList());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var course = await _service.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_authorService.Get(), "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorId,Name,PassMark,DurationInMinutes,Description,DateCreated")] CourseModel course)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Add(course);

                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_authorService.Get(), "Id", "Id", course.AuthorId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var course = await _service.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_authorService.Get(), "Id", "Id", course.AuthorId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorId,Name,PassMark,DurationInMinutes,Description,DateCreated")] CourseModel course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(course);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["AuthorId"] = new SelectList(_authorService.Get(), "Id", "Id", course.AuthorId);
            return View(course);
        }

       
       

        private bool CourseExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}

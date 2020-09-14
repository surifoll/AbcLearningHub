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
    public class UserCourseExamCertificatesController : Controller
    {
        private readonly IUserCourseExamCertificateService _context;
        private readonly IUserCourseExamService _userCourseService;

        public UserCourseExamCertificatesController(IUserCourseExamCertificateService context, IUserCourseExamService userCourseService)
        {
            _context = context;
            _userCourseService = userCourseService;
        }

        // GET: UserCourseExamCertificates
        public async Task<IActionResult> Index()
        {
            var abcLearningHubContext = _context.Get();
            return View(abcLearningHubContext);
        }

        // GET: UserCourseExamCertificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourseExamCertificate =  _context.Get()
              .FirstOrDefault(m => m.Id == id);
            if (userCourseExamCertificate == null)
            {
                return NotFound();
            }

            return View(userCourseExamCertificate);
        }

        // GET: UserCourseExamCertificates/Create
        public IActionResult Create()
        {
            ViewData["UserCourseExamId"] = new SelectList(_userCourseService.Get(), "Id", "Id");
            return View();
        }

        // POST: UserCourseExamCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserCourseExamId,DateCompleted,Title")] UserCourseExamCertificateModel userCourseExamCertificate)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(userCourseExamCertificate);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCourseExamId"] = new SelectList(_userCourseService.Get(), "Id", "CourseName", userCourseExamCertificate.UserCourseExamId);
            return View(userCourseExamCertificate);
        }

        // GET: UserCourseExamCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourseExamCertificate =  _context.Get()
                .FirstOrDefault(m => m.Id == id);
            if (userCourseExamCertificate == null)
            {
                return NotFound();
            }
            ViewData["UserCourseExamId"] = new SelectList(_userCourseService.Get(), "Id", "CourseName", userCourseExamCertificate.UserCourseExamId);
            return View(userCourseExamCertificate);
        }

        // POST: UserCourseExamCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserCourseExamId,DateCompleted,Title")] UserCourseExamCertificateModel userCourseExamCertificate)
        {
            if (id != userCourseExamCertificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(userCourseExamCertificate);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCourseExamCertificateExists(userCourseExamCertificate.Id))
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
            ViewData["UserCourseExamId"] = new SelectList(_userCourseService.Get(), "Id", "CourseName", userCourseExamCertificate.UserCourseExamId);
            return View(userCourseExamCertificate);
        }

       

       
        private bool UserCourseExamCertificateExists(int id)
        {
            var userCourseExamCertificate = _context.Get()
                .FirstOrDefault(m => m.Id == id);
            return userCourseExamCertificate != null;
        }
    }
}

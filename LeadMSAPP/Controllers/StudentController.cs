using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeadMSAPP.Data;
using LeadMSAPP.Models;

namespace LeadMSAPP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student.Include(s => s.EntityStatus).Include(s => s.LeadStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.EntityStatus)
                .Include(s => s.LeadStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.Batch, "Id", "Name");
            ViewData["EntityStatusId"] = new SelectList(_context.EntityStatus, "Id", "StatusName");
            ViewData["LeadStatusId"] = new SelectList(_context.LeadStatus, "Id", "Status");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,DateofBirth,Address,City,State,ZipCode,Country,CreatedAt,UpdatedAt,LeadStatusId,EntityStatusId,BatchId")] Student student)
        {
            if (ModelState.IsValid)
            {
                var batch = _context.Batch.Find(student.BatchId);


                _context.Add(student);
                await _context.SaveChangesAsync();
                if (student.Id !=0)
                {
                    var enroll = new Enroll();
                    enroll.StudentId = student.Id;
                    enroll.BatchId = student.BatchId;
                    _context.Add(enroll);
                    await _context.SaveChangesAsync();
                }
                
            
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.Batch, "Id", "Name");
            ViewData["EntityStatusId"] = new SelectList(_context.EntityStatus, "Id", "StatusName", student.EntityStatusId);
            ViewData["LeadStatusId"] = new SelectList(_context.LeadStatus, "Id", "Status", student.LeadStatusId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["EntityStatusId"] = new SelectList(_context.EntityStatus, "Id", "StatusName", student.EntityStatusId);
            ViewData["LeadStatusId"] = new SelectList(_context.LeadStatus, "Id", "Status", student.LeadStatusId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,DateofBirth,Address,City,State,ZipCode,Country,CreatedAt,UpdatedAt,LeadStatusId,EntityStatusId,BatchId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["EntityStatusId"] = new SelectList(_context.EntityStatus, "Id", "StatusName", student.EntityStatusId);
            ViewData["LeadStatusId"] = new SelectList(_context.LeadStatus, "Id", "Status", student.LeadStatusId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.EntityStatus)
                .Include(s => s.LeadStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}

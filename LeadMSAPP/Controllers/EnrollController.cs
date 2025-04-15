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
    public class EnrollController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enroll
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enroll.Include(e => e.Batch).Include(e => e.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enroll/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enroll
                .Include(e => e.Batch)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // GET: Enroll/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.Batch, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name");
            return View();
        }

        // POST: Enroll/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FeePaid,TotalFee,EnrollmentDate,UpdatedAt,StudentId,BatchId")] Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.Batch, "Id", "Name", enroll.BatchId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name", enroll.StudentId);
            return View(enroll);
        }

        // GET: Enroll/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enroll.FindAsync(id);
            if (enroll == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.Batch, "Id", "Name", enroll.BatchId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name", enroll.StudentId);
            return View(enroll);
        }

        // POST: Enroll/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FeePaid,TotalFee,EnrollmentDate,UpdatedAt,StudentId,BatchId")] Enroll enroll)
        {
            if (id != enroll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollExists(enroll.Id))
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
            ViewData["BatchId"] = new SelectList(_context.Batch, "Id", "Name", enroll.BatchId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name", enroll.StudentId);
            return View(enroll);
        }

        // GET: Enroll/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enroll
                .Include(e => e.Batch)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // POST: Enroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enroll = await _context.Enroll.FindAsync(id);
            if (enroll != null)
            {
                _context.Enroll.Remove(enroll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollExists(int id)
        {
            return _context.Enroll.Any(e => e.Id == id);
        }
    }
}

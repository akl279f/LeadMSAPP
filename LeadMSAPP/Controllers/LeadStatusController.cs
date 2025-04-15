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
    public class LeadStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeadStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadStatus.ToListAsync());
        }

        // GET: LeadStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadStatus = await _context.LeadStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadStatus == null)
            {
                return NotFound();
            }

            return View(leadStatus);
        }

        // GET: LeadStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeadStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Description,LeadType,IsActive,CreatedAt,UpdatedAt")] LeadStatus leadStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadStatus);
        }

        // GET: LeadStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadStatus = await _context.LeadStatus.FindAsync(id);
            if (leadStatus == null)
            {
                return NotFound();
            }
            return View(leadStatus);
        }

        // POST: LeadStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Description,LeadType,IsActive,CreatedAt,UpdatedAt")] LeadStatus leadStatus)
        {
            if (id != leadStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadStatusExists(leadStatus.Id))
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
            return View(leadStatus);
        }

        // GET: LeadStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadStatus = await _context.LeadStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadStatus == null)
            {
                return NotFound();
            }

            return View(leadStatus);
        }

        // POST: LeadStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leadStatus = await _context.LeadStatus.FindAsync(id);
            if (leadStatus != null)
            {
                _context.LeadStatus.Remove(leadStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadStatusExists(int id)
        {
            return _context.LeadStatus.Any(e => e.Id == id);
        }
    }
}

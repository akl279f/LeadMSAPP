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
    public class EntityStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntityStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EntityStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityStatus.ToListAsync());
        }

        // GET: EntityStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityStatus = await _context.EntityStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityStatus == null)
            {
                return NotFound();
            }

            return View(entityStatus);
        }

        // GET: EntityStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName,Description,StatusType,IsActive,CreatedAt,UpdatedAt")] EntityStatus entityStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityStatus);
        }

        // GET: EntityStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityStatus = await _context.EntityStatus.FindAsync(id);
            if (entityStatus == null)
            {
                return NotFound();
            }
            return View(entityStatus);
        }

        // POST: EntityStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName,Description,StatusType,IsActive,CreatedAt,UpdatedAt")] EntityStatus entityStatus)
        {
            if (id != entityStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityStatusExists(entityStatus.Id))
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
            return View(entityStatus);
        }

        // GET: EntityStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityStatus = await _context.EntityStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityStatus == null)
            {
                return NotFound();
            }

            return View(entityStatus);
        }

        // POST: EntityStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityStatus = await _context.EntityStatus.FindAsync(id);
            if (entityStatus != null)
            {
                _context.EntityStatus.Remove(entityStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityStatusExists(int id)
        {
            return _context.EntityStatus.Any(e => e.Id == id);
        }
    }
}

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
    public class PaymentHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentHistory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PaymentHistory.Include(p => p.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PaymentHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            return View(paymentHistory);
        }

        // GET: PaymentHistory/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name");
            return View();
        }

        // POST: PaymentHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptNumber,PaymentDate,AmountPaid,PaymentMethod,TotalFee,Due,Remarks,StudentId")] PaymentHistory paymentHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name", paymentHistory.StudentId);
            return View(paymentHistory);
        }

        // GET: PaymentHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory.FindAsync(id);
            if (paymentHistory == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name", paymentHistory.StudentId);
            return View(paymentHistory);
        }

        // POST: PaymentHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptNumber,PaymentDate,AmountPaid,PaymentMethod,TotalFee,Due,Remarks,StudentId")] PaymentHistory paymentHistory)
        {
            if (id != paymentHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentHistoryExists(paymentHistory.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name", paymentHistory.StudentId);
            return View(paymentHistory);
        }

        // GET: PaymentHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            return View(paymentHistory);
        }

        // POST: PaymentHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentHistory = await _context.PaymentHistory.FindAsync(id);
            if (paymentHistory != null)
            {
                _context.PaymentHistory.Remove(paymentHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentHistoryExists(int id)
        {
            return _context.PaymentHistory.Any(e => e.Id == id);
        }
    }
}

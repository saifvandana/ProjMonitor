using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMonitor.Models;

namespace ProjectMonitor.Controllers
{
    public class DenaturationsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public DenaturationsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Denaturations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Denaturation.ToListAsync());
        }

        // GET: Denaturations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denaturation = await _context.Denaturation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denaturation == null)
            {
                return NotFound();
            }

            return View(denaturation);
        }

        // GET: Denaturations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Denaturations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature,Duration,Cycles")] Denaturation denaturation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denaturation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denaturation);
        }

        // GET: Denaturations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denaturation = await _context.Denaturation.FindAsync(id);
            if (denaturation == null)
            {
                return NotFound();
            }
            return View(denaturation);
        }

        // POST: Denaturations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature,Duration,Cycles")] Denaturation denaturation)
        {
            if (id != denaturation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denaturation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenaturationExists(denaturation.Id))
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
            return View(denaturation);
        }

        // GET: Denaturations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denaturation = await _context.Denaturation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denaturation == null)
            {
                return NotFound();
            }

            return View(denaturation);
        }

        // POST: Denaturations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denaturation = await _context.Denaturation.FindAsync(id);
            _context.Denaturation.Remove(denaturation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenaturationExists(int id)
        {
            return _context.Denaturation.Any(e => e.Id == id);
        }
    }
}

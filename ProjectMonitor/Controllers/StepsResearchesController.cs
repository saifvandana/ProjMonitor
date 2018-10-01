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
    public class StepsResearchesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public StepsResearchesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: StepsResearches
        public async Task<IActionResult> Index()
        {
            return View(await _context.StepsResearch.ToListAsync());
        }

        // GET: StepsResearches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stepsResearch = await _context.StepsResearch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stepsResearch == null)
            {
                return NotFound();
            }

            return View(stepsResearch);
        }

        // GET: StepsResearches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StepsResearches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Metodlar,Referans")] StepsResearch stepsResearch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stepsResearch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stepsResearch);
        }

        // GET: StepsResearches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stepsResearch = await _context.StepsResearch.FindAsync(id);
            if (stepsResearch == null)
            {
                return NotFound();
            }
            return View(stepsResearch);
        }

        // POST: StepsResearches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Metodlar,Referans")] StepsResearch stepsResearch)
        {
            if (id != stepsResearch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stepsResearch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StepsResearchExists(stepsResearch.Id))
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
            return View(stepsResearch);
        }

        // GET: StepsResearches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stepsResearch = await _context.StepsResearch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stepsResearch == null)
            {
                return NotFound();
            }

            return View(stepsResearch);
        }

        // POST: StepsResearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stepsResearch = await _context.StepsResearch.FindAsync(id);
            _context.StepsResearch.Remove(stepsResearch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StepsResearchExists(int id)
        {
            return _context.StepsResearch.Any(e => e.Id == id);
        }
    }
}

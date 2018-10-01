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
    public class ResultsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ResultsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.Results.Include(r => r.Sample);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Results
                .Include(r => r.Sample)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SampleExtractionId,NanogramDegeri,TeslimAlan,TespitDegeri1,TespitDegeri2,TespitDegeri3,TespitDegeri4,TespitDegeri5,TespitDegeri6,TespitDegeri7,TespitDegeri8,TespitDegeri9,GorselLinki,Onay")] Results results)
        {
            if (ModelState.IsValid)
            {
                _context.Add(results);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id", results.SampleExtractionId);
            return View(results);
        }

        // GET: Results/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Results.FindAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id", results.SampleExtractionId);
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SampleExtractionId,NanogramDegeri,TeslimAlan,TespitDegeri1,TespitDegeri2,TespitDegeri3,TespitDegeri4,TespitDegeri5,TespitDegeri6,TespitDegeri7,TespitDegeri8,TespitDegeri9,GorselLinki,Onay")] Results results)
        {
            if (id != results.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(results);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultsExists(results.Id))
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
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id", results.SampleExtractionId);
            return View(results);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Results
                .Include(r => r.Sample)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var results = await _context.Results.FindAsync(id);
            _context.Results.Remove(results);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultsExists(int id)
        {
            return _context.Results.Any(e => e.Id == id);
        }
    }
}

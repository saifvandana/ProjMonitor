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
    public class SampleProvidersController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public SampleProvidersController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: SampleProviders
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleProvider.ToListAsync());
        }

        // GET: SampleProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleProvider = await _context.SampleProvider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleProvider == null)
            {
                return NotFound();
            }

            return View(sampleProvider);
        }

        // GET: SampleProviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProviderName")] SampleProvider sampleProvider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleProvider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleProvider);
        }

        // GET: SampleProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleProvider = await _context.SampleProvider.FindAsync(id);
            if (sampleProvider == null)
            {
                return NotFound();
            }
            return View(sampleProvider);
        }

        // POST: SampleProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProviderName")] SampleProvider sampleProvider)
        {
            if (id != sampleProvider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleProvider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleProviderExists(sampleProvider.Id))
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
            return View(sampleProvider);
        }

        // GET: SampleProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleProvider = await _context.SampleProvider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleProvider == null)
            {
                return NotFound();
            }

            return View(sampleProvider);
        }

        // POST: SampleProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sampleProvider = await _context.SampleProvider.FindAsync(id);
            _context.SampleProvider.Remove(sampleProvider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleProviderExists(int id)
        {
            return _context.SampleProvider.Any(e => e.Id == id);
        }
    }
}

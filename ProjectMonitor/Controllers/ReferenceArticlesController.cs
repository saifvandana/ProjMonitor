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
    public class ReferenceArticlesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ReferenceArticlesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: ReferenceArticles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReferenceArticles.ToListAsync());
        }

        // GET: ReferenceArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceArticles = await _context.ReferenceArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referenceArticles == null)
            {
                return NotFound();
            }

            return View(referenceArticles);
        }

        // GET: ReferenceArticles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReferenceArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReferansMakaleler")] ReferenceArticles referenceArticles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referenceArticles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referenceArticles);
        }

        // GET: ReferenceArticles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceArticles = await _context.ReferenceArticles.FindAsync(id);
            if (referenceArticles == null)
            {
                return NotFound();
            }
            return View(referenceArticles);
        }

        // POST: ReferenceArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReferansMakaleler")] ReferenceArticles referenceArticles)
        {
            if (id != referenceArticles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referenceArticles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceArticlesExists(referenceArticles.Id))
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
            return View(referenceArticles);
        }

        // GET: ReferenceArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceArticles = await _context.ReferenceArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referenceArticles == null)
            {
                return NotFound();
            }

            return View(referenceArticles);
        }

        // POST: ReferenceArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referenceArticles = await _context.ReferenceArticles.FindAsync(id);
            _context.ReferenceArticles.Remove(referenceArticles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceArticlesExists(int id)
        {
            return _context.ReferenceArticles.Any(e => e.Id == id);
        }
    }
}

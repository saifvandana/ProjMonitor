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
    public class EnzymesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public EnzymesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Enzymes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enzyme.ToListAsync());
        }

        // GET: Enzymes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enzyme = await _context.Enzyme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enzyme == null)
            {
                return NotFound();
            }

            return View(enzyme);
        }

        // GET: Enzymes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enzymes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Hacim")] Enzyme enzyme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enzyme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enzyme);
        }

        // GET: Enzymes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enzyme = await _context.Enzyme.FindAsync(id);
            if (enzyme == null)
            {
                return NotFound();
            }
            return View(enzyme);
        }

        // POST: Enzymes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Hacim")] Enzyme enzyme)
        {
            if (id != enzyme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enzyme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnzymeExists(enzyme.Id))
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
            return View(enzyme);
        }

        // GET: Enzymes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enzyme = await _context.Enzyme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enzyme == null)
            {
                return NotFound();
            }

            return View(enzyme);
        }

        // POST: Enzymes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enzyme = await _context.Enzyme.FindAsync(id);
            _context.Enzyme.Remove(enzyme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnzymeExists(int id)
        {
            return _context.Enzyme.Any(e => e.Id == id);
        }
    }
}

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
    public class Pcr2Controller : Controller
    {
        private readonly ProjectMonitorContext _context;

        public Pcr2Controller(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Pcr2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pcr2.ToListAsync());
        }

        // GET: Pcr2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcr2 = await _context.Pcr2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pcr2 == null)
            {
                return NotFound();
            }

            return View(pcr2);
        }

        // GET: Pcr2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pcr2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature,Duration,Cycles")] Pcr2 pcr2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pcr2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pcr2);
        }

        // GET: Pcr2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcr2 = await _context.Pcr2.FindAsync(id);
            if (pcr2 == null)
            {
                return NotFound();
            }
            return View(pcr2);
        }

        // POST: Pcr2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature,Duration,Cycles")] Pcr2 pcr2)
        {
            if (id != pcr2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pcr2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pcr2Exists(pcr2.Id))
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
            return View(pcr2);
        }

        // GET: Pcr2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcr2 = await _context.Pcr2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pcr2 == null)
            {
                return NotFound();
            }

            return View(pcr2);
        }

        // POST: Pcr2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pcr2 = await _context.Pcr2.FindAsync(id);
            _context.Pcr2.Remove(pcr2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pcr2Exists(int id)
        {
            return _context.Pcr2.Any(e => e.Id == id);
        }
    }
}

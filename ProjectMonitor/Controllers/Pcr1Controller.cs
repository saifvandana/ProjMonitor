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
    public class Pcr1Controller : Controller
    {
        private readonly ProjectMonitorContext _context;

        public Pcr1Controller(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Pcr1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pcr1.ToListAsync());
        }

        // GET: Pcr1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcr1 = await _context.Pcr1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pcr1 == null)
            {
                return NotFound();
            }

            return View(pcr1);
        }

        // GET: Pcr1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pcr1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature,Duration,Cycles")] Pcr1 pcr1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pcr1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pcr1);
        }

        // GET: Pcr1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcr1 = await _context.Pcr1.FindAsync(id);
            if (pcr1 == null)
            {
                return NotFound();
            }
            return View(pcr1);
        }

        // POST: Pcr1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature,Duration,Cycles")] Pcr1 pcr1)
        {
            if (id != pcr1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pcr1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pcr1Exists(pcr1.Id))
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
            return View(pcr1);
        }

        // GET: Pcr1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcr1 = await _context.Pcr1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pcr1 == null)
            {
                return NotFound();
            }

            return View(pcr1);
        }

        // POST: Pcr1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pcr1 = await _context.Pcr1.FindAsync(id);
            _context.Pcr1.Remove(pcr1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pcr1Exists(int id)
        {
            return _context.Pcr1.Any(e => e.Id == id);
        }
    }
}

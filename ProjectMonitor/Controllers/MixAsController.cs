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
    public class MixAsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public MixAsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: MixAs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MixA.ToListAsync());
        }

        // GET: MixAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixA = await _context.MixA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mixA == null)
            {
                return NotFound();
            }

            return View(mixA);
        }

        // GET: MixAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MixAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Hacim")] MixA mixA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mixA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mixA);
        }

        // GET: MixAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixA = await _context.MixA.FindAsync(id);
            if (mixA == null)
            {
                return NotFound();
            }
            return View(mixA);
        }

        // POST: MixAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Hacim")] MixA mixA)
        {
            if (id != mixA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mixA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MixAExists(mixA.Id))
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
            return View(mixA);
        }

        // GET: MixAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixA = await _context.MixA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mixA == null)
            {
                return NotFound();
            }

            return View(mixA);
        }

        // POST: MixAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mixA = await _context.MixA.FindAsync(id);
            _context.MixA.Remove(mixA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MixAExists(int id)
        {
            return _context.MixA.Any(e => e.Id == id);
        }
    }
}

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
    public class MixBsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public MixBsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: MixBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MixB.ToListAsync());
        }

        // GET: MixBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixB = await _context.MixB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mixB == null)
            {
                return NotFound();
            }

            return View(mixB);
        }

        // GET: MixBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MixBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Hacim")] MixB mixB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mixB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mixB);
        }

        // GET: MixBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixB = await _context.MixB.FindAsync(id);
            if (mixB == null)
            {
                return NotFound();
            }
            return View(mixB);
        }

        // POST: MixBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Hacim")] MixB mixB)
        {
            if (id != mixB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mixB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MixBExists(mixB.Id))
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
            return View(mixB);
        }

        // GET: MixBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixB = await _context.MixB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mixB == null)
            {
                return NotFound();
            }

            return View(mixB);
        }

        // POST: MixBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mixB = await _context.MixB.FindAsync(id);
            _context.MixB.Remove(mixB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MixBExists(int id)
        {
            return _context.MixB.Any(e => e.Id == id);
        }
    }
}

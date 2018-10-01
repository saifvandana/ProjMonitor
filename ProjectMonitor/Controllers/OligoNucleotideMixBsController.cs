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
    public class OligoNucleotideMixBsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public OligoNucleotideMixBsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: OligoNucleotideMixBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OligoNucleotideMixB.ToListAsync());
        }

        // GET: OligoNucleotideMixBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligoNucleotideMixB = await _context.OligoNucleotideMixB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oligoNucleotideMixB == null)
            {
                return NotFound();
            }

            return View(oligoNucleotideMixB);
        }

        // GET: OligoNucleotideMixBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OligoNucleotideMixBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MixBCode,Aciklama,HazirlamaTarihi")] OligoNucleotideMixB oligoNucleotideMixB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oligoNucleotideMixB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oligoNucleotideMixB);
        }

        // GET: OligoNucleotideMixBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligoNucleotideMixB = await _context.OligoNucleotideMixB.FindAsync(id);
            if (oligoNucleotideMixB == null)
            {
                return NotFound();
            }
            return View(oligoNucleotideMixB);
        }

        // POST: OligoNucleotideMixBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MixBCode,Aciklama,HazirlamaTarihi")] OligoNucleotideMixB oligoNucleotideMixB)
        {
            if (id != oligoNucleotideMixB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oligoNucleotideMixB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OligoNucleotideMixBExists(oligoNucleotideMixB.Id))
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
            return View(oligoNucleotideMixB);
        }

        // GET: OligoNucleotideMixBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligoNucleotideMixB = await _context.OligoNucleotideMixB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oligoNucleotideMixB == null)
            {
                return NotFound();
            }

            return View(oligoNucleotideMixB);
        }

        // POST: OligoNucleotideMixBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oligoNucleotideMixB = await _context.OligoNucleotideMixB.FindAsync(id);
            _context.OligoNucleotideMixB.Remove(oligoNucleotideMixB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OligoNucleotideMixBExists(int id)
        {
            return _context.OligoNucleotideMixB.Any(e => e.Id == id);
        }
    }
}

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
    public class OligonucleotideInfoesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public OligonucleotideInfoesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: OligonucleotideInfoes
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.OligonucleotideInfo.Include(o => o.OligoNucleotide).Include(o => o.OligoNucleotideMixB);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: OligonucleotideInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligonucleotideInfo = await _context.OligonucleotideInfo
                .Include(o => o.OligoNucleotide)
                .Include(o => o.OligoNucleotideMixB)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oligonucleotideInfo == null)
            {
                return NotFound();
            }

            return View(oligonucleotideInfo);
        }

        // GET: OligonucleotideInfoes/Create
        public IActionResult Create()
        {
            ViewData["OligoNucleotideId"] = new SelectList(_context.OligoNucleotide, "Id", "Id");
            ViewData["OligoNucleotideMixBId"] = new SelectList(_context.Set<OligoNucleotideMixB>(), "Id", "Id");
            return View();
        }

        // POST: OligonucleotideInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OligoNucleotideId,OligoNucleotideMixBId")] OligonucleotideInfo oligonucleotideInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oligonucleotideInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OligoNucleotideId"] = new SelectList(_context.OligoNucleotide, "Id", "Id", oligonucleotideInfo.OligoNucleotideId);
            ViewData["OligoNucleotideMixBId"] = new SelectList(_context.Set<OligoNucleotideMixB>(), "Id", "Id", oligonucleotideInfo.OligoNucleotideMixBId);
            return View(oligonucleotideInfo);
        }

        // GET: OligonucleotideInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligonucleotideInfo = await _context.OligonucleotideInfo.FindAsync(id);
            if (oligonucleotideInfo == null)
            {
                return NotFound();
            }
            ViewData["OligoNucleotideId"] = new SelectList(_context.OligoNucleotide, "Id", "Id", oligonucleotideInfo.OligoNucleotideId);
            ViewData["OligoNucleotideMixBId"] = new SelectList(_context.Set<OligoNucleotideMixB>(), "Id", "Id", oligonucleotideInfo.OligoNucleotideMixBId);
            return View(oligonucleotideInfo);
        }

        // POST: OligonucleotideInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OligoNucleotideId,OligoNucleotideMixBId")] OligonucleotideInfo oligonucleotideInfo)
        {
            if (id != oligonucleotideInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oligonucleotideInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OligonucleotideInfoExists(oligonucleotideInfo.Id))
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
            ViewData["OligoNucleotideId"] = new SelectList(_context.OligoNucleotide, "Id", "Id", oligonucleotideInfo.OligoNucleotideId);
            ViewData["OligoNucleotideMixBId"] = new SelectList(_context.Set<OligoNucleotideMixB>(), "Id", "Id", oligonucleotideInfo.OligoNucleotideMixBId);
            return View(oligonucleotideInfo);
        }

        // GET: OligonucleotideInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligonucleotideInfo = await _context.OligonucleotideInfo
                .Include(o => o.OligoNucleotide)
                .Include(o => o.OligoNucleotideMixB)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oligonucleotideInfo == null)
            {
                return NotFound();
            }

            return View(oligonucleotideInfo);
        }

        // POST: OligonucleotideInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oligonucleotideInfo = await _context.OligonucleotideInfo.FindAsync(id);
            _context.OligonucleotideInfo.Remove(oligonucleotideInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OligonucleotideInfoExists(int id)
        {
            return _context.OligonucleotideInfo.Any(e => e.Id == id);
        }
    }
}

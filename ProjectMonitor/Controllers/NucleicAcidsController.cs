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
    public class NucleicAcidsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public NucleicAcidsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: NucleicAcids
        public async Task<IActionResult> Index()
        {
            return View(await _context.NucleicAcid.ToListAsync());
        }

        // GET: NucleicAcids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nucleicAcid = await _context.NucleicAcid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nucleicAcid == null)
            {
                return NotFound();
            }

            return View(nucleicAcid);
        }

        // GET: NucleicAcids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NucleicAcids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Hacim,Sonuc")] NucleicAcid nucleicAcid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nucleicAcid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nucleicAcid);
        }

        // GET: NucleicAcids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nucleicAcid = await _context.NucleicAcid.FindAsync(id);
            if (nucleicAcid == null)
            {
                return NotFound();
            }
            return View(nucleicAcid);
        }

        // POST: NucleicAcids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Hacim,Sonuc")] NucleicAcid nucleicAcid)
        {
            if (id != nucleicAcid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nucleicAcid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NucleicAcidExists(nucleicAcid.Id))
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
            return View(nucleicAcid);
        }

        // GET: NucleicAcids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nucleicAcid = await _context.NucleicAcid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nucleicAcid == null)
            {
                return NotFound();
            }

            return View(nucleicAcid);
        }

        // POST: NucleicAcids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nucleicAcid = await _context.NucleicAcid.FindAsync(id);
            _context.NucleicAcid.Remove(nucleicAcid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NucleicAcidExists(int id)
        {
            return _context.NucleicAcid.Any(e => e.Id == id);
        }
    }
}

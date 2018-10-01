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
    public class OligoNucleotidesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public OligoNucleotidesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: OligoNucleotides
        public async Task<IActionResult> Index()
        {
            return View(await _context.OligoNucleotide.ToListAsync());
        }

        // GET: OligoNucleotides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligoNucleotide = await _context.OligoNucleotide
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oligoNucleotide == null)
            {
                return NotFound();
            }

            return View(oligoNucleotide);
        }

        // GET: OligoNucleotides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OligoNucleotides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiparisKodu,SiparisTarihi,AlinmaTarihi,HedefGenTur,OligoNucleotideType,BesIsaretleme,NucleotideSequence,UcIsaretleme,NucleotideLength,Tm,GcPercent,SelfComp,Self3Comp,HedefBolgeUzunlugu,PrimerDimertur,KaynakTasarlananSistem")] OligoNucleotide oligoNucleotide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oligoNucleotide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oligoNucleotide);
        }

        // GET: OligoNucleotides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligoNucleotide = await _context.OligoNucleotide.FindAsync(id);
            if (oligoNucleotide == null)
            {
                return NotFound();
            }
            return View(oligoNucleotide);
        }

        // POST: OligoNucleotides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiparisKodu,SiparisTarihi,AlinmaTarihi,HedefGenTur,OligoNucleotideType,BesIsaretleme,NucleotideSequence,UcIsaretleme,NucleotideLength,Tm,GcPercent,SelfComp,Self3Comp,HedefBolgeUzunlugu,PrimerDimertur,KaynakTasarlananSistem")] OligoNucleotide oligoNucleotide)
        {
            if (id != oligoNucleotide.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oligoNucleotide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OligoNucleotideExists(oligoNucleotide.Id))
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
            return View(oligoNucleotide);
        }

        // GET: OligoNucleotides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oligoNucleotide = await _context.OligoNucleotide
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oligoNucleotide == null)
            {
                return NotFound();
            }

            return View(oligoNucleotide);
        }

        // POST: OligoNucleotides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oligoNucleotide = await _context.OligoNucleotide.FindAsync(id);
            _context.OligoNucleotide.Remove(oligoNucleotide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OligoNucleotideExists(int id)
        {
            return _context.OligoNucleotide.Any(e => e.Id == id);
        }
    }
}

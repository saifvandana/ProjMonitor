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
    public class SampleExtractionsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public SampleExtractionsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: SampleExtractions
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleExtraction.ToListAsync());
        }

        // GET: SampleExtractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleExtraction = await _context.SampleExtraction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleExtraction == null)
            {
                return NotFound();
            }

            return View(sampleExtraction);
        }

        // GET: SampleExtractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleExtractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumuneAlisTarihi,TeslimAlinan,TeslimAlan,NumuneIsim,NumuneKodu,NumuneTuru,NumuneKurum,DiagenNukleikAsidKodu,EkstraksiyonTarihi,YapanKisi,Yontem,KullanilanKit,Aciklama")] SampleExtraction sampleExtraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleExtraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleExtraction);
        }

        // GET: SampleExtractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleExtraction = await _context.SampleExtraction.FindAsync(id);
            if (sampleExtraction == null)
            {
                return NotFound();
            }
            return View(sampleExtraction);
        }

        // POST: SampleExtractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumuneAlisTarihi,TeslimAlinan,TeslimAlan,NumuneIsim,NumuneKodu,NumuneTuru,NumuneKurum,DiagenNukleikAsidKodu,EkstraksiyonTarihi,YapanKisi,Yontem,KullanilanKit,Aciklama")] SampleExtraction sampleExtraction)
        {
            if (id != sampleExtraction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleExtraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleExtractionExists(sampleExtraction.Id))
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
            return View(sampleExtraction);
        }

        // GET: SampleExtractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleExtraction = await _context.SampleExtraction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleExtraction == null)
            {
                return NotFound();
            }

            return View(sampleExtraction);
        }

        // POST: SampleExtractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sampleExtraction = await _context.SampleExtraction.FindAsync(id);
            _context.SampleExtraction.Remove(sampleExtraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleExtractionExists(int id)
        {
            return _context.SampleExtraction.Any(e => e.Id == id);
        }
    }
}

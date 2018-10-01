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
    public class PcrProcessesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public PcrProcessesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: PcrProcesses
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.PcrProcess.Include(p => p.Cooling).Include(p => p.Denaturation).Include(p => p.Enzyme).Include(p => p.MixA).Include(p => p.MixB).Include(p => p.NucleicAcid).Include(p => p.Pcr1).Include(p => p.Pcr2).Include(p => p.ResultSlip);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: PcrProcesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcrProcess = await _context.PcrProcess
                .Include(p => p.Cooling)
                .Include(p => p.Denaturation)
                .Include(p => p.Enzyme)
                .Include(p => p.MixA)
                .Include(p => p.MixB)
                .Include(p => p.NucleicAcid)
                .Include(p => p.Pcr1)
                .Include(p => p.Pcr2)
                .Include(p => p.ResultSlip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pcrProcess == null)
            {
                return NotFound();
            }

            return View(pcrProcess);
        }

        // GET: PcrProcesses/Create
        public IActionResult Create()
        {
            ViewData["CoolingId"] = new SelectList(_context.Cooling, "Id", "Id");
            ViewData["DenaturationId"] = new SelectList(_context.Denaturation, "Id", "Id");
            ViewData["EnzymeId"] = new SelectList(_context.Enzyme, "Id", "Id");
            ViewData["MixAId"] = new SelectList(_context.MixA, "Id", "Id");
            ViewData["MixBId"] = new SelectList(_context.MixB, "Id", "Id");
            ViewData["NucleicAcidId"] = new SelectList(_context.NucleicAcid, "Id", "Id");
            ViewData["Pcr1Id"] = new SelectList(_context.Pcr1, "Id", "Id");
            ViewData["Pcr2Id"] = new SelectList(_context.Pcr2, "Id", "Id");
            ViewData["ResultSlipId"] = new SelectList(_context.Set<ResultSlip>(), "Id", "Id");
            return View();
        }

        // POST: PcrProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cihaz,OperatorAdi,Tarih,KayitAdi,CalisanGen,ResultSlipId,Results,MixAId,MixBId,EnzymeId,DH20,DenaturationId,Pcr1Id,Pcr2Id,CoolingId,NucleicAcidId,CalismaAmaci,Yorum")] PcrProcess pcrProcess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pcrProcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoolingId"] = new SelectList(_context.Cooling, "Id", "Id", pcrProcess.CoolingId);
            ViewData["DenaturationId"] = new SelectList(_context.Denaturation, "Id", "Id", pcrProcess.DenaturationId);
            ViewData["EnzymeId"] = new SelectList(_context.Enzyme, "Id", "Id", pcrProcess.EnzymeId);
            ViewData["MixAId"] = new SelectList(_context.MixA, "Id", "Id", pcrProcess.MixAId);
            ViewData["MixBId"] = new SelectList(_context.MixB, "Id", "Id", pcrProcess.MixBId);
            ViewData["NucleicAcidId"] = new SelectList(_context.NucleicAcid, "Id", "Id", pcrProcess.NucleicAcidId);
            ViewData["Pcr1Id"] = new SelectList(_context.Pcr1, "Id", "Id", pcrProcess.Pcr1Id);
            ViewData["Pcr2Id"] = new SelectList(_context.Pcr2, "Id", "Id", pcrProcess.Pcr2Id);
            ViewData["ResultSlipId"] = new SelectList(_context.Set<ResultSlip>(), "Id", "Id", pcrProcess.ResultSlipId);
            return View(pcrProcess);
        }

        // GET: PcrProcesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcrProcess = await _context.PcrProcess.FindAsync(id);
            if (pcrProcess == null)
            {
                return NotFound();
            }
            ViewData["CoolingId"] = new SelectList(_context.Cooling, "Id", "Id", pcrProcess.CoolingId);
            ViewData["DenaturationId"] = new SelectList(_context.Denaturation, "Id", "Id", pcrProcess.DenaturationId);
            ViewData["EnzymeId"] = new SelectList(_context.Enzyme, "Id", "Id", pcrProcess.EnzymeId);
            ViewData["MixAId"] = new SelectList(_context.MixA, "Id", "Id", pcrProcess.MixAId);
            ViewData["MixBId"] = new SelectList(_context.MixB, "Id", "Id", pcrProcess.MixBId);
            ViewData["NucleicAcidId"] = new SelectList(_context.NucleicAcid, "Id", "Id", pcrProcess.NucleicAcidId);
            ViewData["Pcr1Id"] = new SelectList(_context.Pcr1, "Id", "Id", pcrProcess.Pcr1Id);
            ViewData["Pcr2Id"] = new SelectList(_context.Pcr2, "Id", "Id", pcrProcess.Pcr2Id);
            ViewData["ResultSlipId"] = new SelectList(_context.Set<ResultSlip>(), "Id", "Id", pcrProcess.ResultSlipId);
            return View(pcrProcess);
        }

        // POST: PcrProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cihaz,OperatorAdi,Tarih,KayitAdi,CalisanGen,ResultSlipId,Results,MixAId,MixBId,EnzymeId,DH20,DenaturationId,Pcr1Id,Pcr2Id,CoolingId,NucleicAcidId,CalismaAmaci,Yorum")] PcrProcess pcrProcess)
        {
            if (id != pcrProcess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pcrProcess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PcrProcessExists(pcrProcess.Id))
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
            ViewData["CoolingId"] = new SelectList(_context.Cooling, "Id", "Id", pcrProcess.CoolingId);
            ViewData["DenaturationId"] = new SelectList(_context.Denaturation, "Id", "Id", pcrProcess.DenaturationId);
            ViewData["EnzymeId"] = new SelectList(_context.Enzyme, "Id", "Id", pcrProcess.EnzymeId);
            ViewData["MixAId"] = new SelectList(_context.MixA, "Id", "Id", pcrProcess.MixAId);
            ViewData["MixBId"] = new SelectList(_context.MixB, "Id", "Id", pcrProcess.MixBId);
            ViewData["NucleicAcidId"] = new SelectList(_context.NucleicAcid, "Id", "Id", pcrProcess.NucleicAcidId);
            ViewData["Pcr1Id"] = new SelectList(_context.Pcr1, "Id", "Id", pcrProcess.Pcr1Id);
            ViewData["Pcr2Id"] = new SelectList(_context.Pcr2, "Id", "Id", pcrProcess.Pcr2Id);
            ViewData["ResultSlipId"] = new SelectList(_context.Set<ResultSlip>(), "Id", "Id", pcrProcess.ResultSlipId);
            return View(pcrProcess);
        }

        // GET: PcrProcesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pcrProcess = await _context.PcrProcess
                .Include(p => p.Cooling)
                .Include(p => p.Denaturation)
                .Include(p => p.Enzyme)
                .Include(p => p.MixA)
                .Include(p => p.MixB)
                .Include(p => p.NucleicAcid)
                .Include(p => p.Pcr1)
                .Include(p => p.Pcr2)
                .Include(p => p.ResultSlip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pcrProcess == null)
            {
                return NotFound();
            }

            return View(pcrProcess);
        }

        // POST: PcrProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pcrProcess = await _context.PcrProcess.FindAsync(id);
            _context.PcrProcess.Remove(pcrProcess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PcrProcessExists(int id)
        {
            return _context.PcrProcess.Any(e => e.Id == id);
        }
    }
}

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
    public class ProjectsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ProjectsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.Projects.Include(p => p.OligonucleotideInfo).Include(p => p.PcrProcess).Include(p => p.ProjectResearchPlan).Include(p => p.ProjectState).Include(p => p.Results).Include(p => p.SampleExtraction).Include(p => p.SampleProvider).Include(p => p.WorkItemMonitor);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(p => p.OligonucleotideInfo)
                .Include(p => p.PcrProcess)
                .Include(p => p.ProjectResearchPlan)
                .Include(p => p.ProjectState)
                .Include(p => p.Results)
                .Include(p => p.SampleExtraction)
                .Include(p => p.SampleProvider)
                .Include(p => p.WorkItemMonitor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["OligonucleotideInfoId"] = new SelectList(_context.OligonucleotideInfo, "Id", "Id");
            ViewData["PcrProcessId"] = new SelectList(_context.PcrProcess, "Id", "Id");
            ViewData["ProjectResearchPlanId"] = new SelectList(_context.ProjectResearchPlan, "Id", "Id");
            ViewData["ProjectStateId"] = new SelectList(_context.Set<ProjectState>(), "Id", "Id");
            ViewData["ResultsId"] = new SelectList(_context.Set<Results>(), "Id", "Id");
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id");
            ViewData["SampleProviderId"] = new SelectList(_context.Set<SampleProvider>(), "Id", "Id");
            ViewData["WorkItemMonitorId"] = new SelectList(_context.Set<WorkItemMonitor>(), "Id", "Id");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UhtNumber,SdfNumber,ProjeBaslangicTarihi,ProjeBitisTarihi,KullanilacakMesai,BeklenenNumuneAdedi,ProjeSorumlusu,ProjeTuru,IlgiliMusteri,IlgiliMusteriTelNo,IlgiliMusteriEmail,IlgiliMusteriTemsilcisi,ProjeServerLink,ProjeAciklama,ProjeSonDurum,ProjectResearchPlanId,WorkItemMonitorId,OligonucleotideInfoId,SampleExtractionId,PcrProcessId,ResultsId,ProjectStateId,SampleProviderId,ProjectReport")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OligonucleotideInfoId"] = new SelectList(_context.OligonucleotideInfo, "Id", "Id", projects.OligonucleotideInfoId);
            ViewData["PcrProcessId"] = new SelectList(_context.PcrProcess, "Id", "Id", projects.PcrProcessId);
            ViewData["ProjectResearchPlanId"] = new SelectList(_context.ProjectResearchPlan, "Id", "Id", projects.ProjectResearchPlanId);
            ViewData["ProjectStateId"] = new SelectList(_context.Set<ProjectState>(), "Id", "Id", projects.ProjectStateId);
            ViewData["ResultsId"] = new SelectList(_context.Set<Results>(), "Id", "Id", projects.ResultsId);
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id", projects.SampleExtractionId);
            ViewData["SampleProviderId"] = new SelectList(_context.Set<SampleProvider>(), "Id", "Id", projects.SampleProviderId);
            ViewData["WorkItemMonitorId"] = new SelectList(_context.Set<WorkItemMonitor>(), "Id", "Id", projects.WorkItemMonitorId);
            return View(projects);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            ViewData["OligonucleotideInfoId"] = new SelectList(_context.OligonucleotideInfo, "Id", "Id", projects.OligonucleotideInfoId);
            ViewData["PcrProcessId"] = new SelectList(_context.PcrProcess, "Id", "Id", projects.PcrProcessId);
            ViewData["ProjectResearchPlanId"] = new SelectList(_context.ProjectResearchPlan, "Id", "Id", projects.ProjectResearchPlanId);
            ViewData["ProjectStateId"] = new SelectList(_context.Set<ProjectState>(), "Id", "Id", projects.ProjectStateId);
            ViewData["ResultsId"] = new SelectList(_context.Set<Results>(), "Id", "Id", projects.ResultsId);
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id", projects.SampleExtractionId);
            ViewData["SampleProviderId"] = new SelectList(_context.Set<SampleProvider>(), "Id", "Id", projects.SampleProviderId);
            ViewData["WorkItemMonitorId"] = new SelectList(_context.Set<WorkItemMonitor>(), "Id", "Id", projects.WorkItemMonitorId);
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UhtNumber,SdfNumber,ProjeBaslangicTarihi,ProjeBitisTarihi,KullanilacakMesai,BeklenenNumuneAdedi,ProjeSorumlusu,ProjeTuru,IlgiliMusteri,IlgiliMusteriTelNo,IlgiliMusteriEmail,IlgiliMusteriTemsilcisi,ProjeServerLink,ProjeAciklama,ProjeSonDurum,ProjectResearchPlanId,WorkItemMonitorId,OligonucleotideInfoId,SampleExtractionId,PcrProcessId,ResultsId,ProjectStateId,SampleProviderId,ProjectReport")] Projects projects)
        {
            if (id != projects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.Id))
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
            ViewData["OligonucleotideInfoId"] = new SelectList(_context.OligonucleotideInfo, "Id", "Id", projects.OligonucleotideInfoId);
            ViewData["PcrProcessId"] = new SelectList(_context.PcrProcess, "Id", "Id", projects.PcrProcessId);
            ViewData["ProjectResearchPlanId"] = new SelectList(_context.ProjectResearchPlan, "Id", "Id", projects.ProjectResearchPlanId);
            ViewData["ProjectStateId"] = new SelectList(_context.Set<ProjectState>(), "Id", "Id", projects.ProjectStateId);
            ViewData["ResultsId"] = new SelectList(_context.Set<Results>(), "Id", "Id", projects.ResultsId);
            ViewData["SampleExtractionId"] = new SelectList(_context.Set<SampleExtraction>(), "Id", "Id", projects.SampleExtractionId);
            ViewData["SampleProviderId"] = new SelectList(_context.Set<SampleProvider>(), "Id", "Id", projects.SampleProviderId);
            ViewData["WorkItemMonitorId"] = new SelectList(_context.Set<WorkItemMonitor>(), "Id", "Id", projects.WorkItemMonitorId);
            return View(projects);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(p => p.OligonucleotideInfo)
                .Include(p => p.PcrProcess)
                .Include(p => p.ProjectResearchPlan)
                .Include(p => p.ProjectState)
                .Include(p => p.Results)
                .Include(p => p.SampleExtraction)
                .Include(p => p.SampleProvider)
                .Include(p => p.WorkItemMonitor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}

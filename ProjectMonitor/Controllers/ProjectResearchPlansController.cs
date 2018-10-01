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
    public class ProjectResearchPlansController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ProjectResearchPlansController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: ProjectResearchPlans
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.ProjectResearchPlan.Include(p => p.ProjectSteps).Include(p => p.ReferenceArticles).Include(p => p.StepsResearch).Include(p => p.WorkItems);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: ProjectResearchPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectResearchPlan = await _context.ProjectResearchPlan
                .Include(p => p.ProjectSteps)
                .Include(p => p.ReferenceArticles)
                .Include(p => p.StepsResearch)
                .Include(p => p.WorkItems)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectResearchPlan == null)
            {
                return NotFound();
            }

            return View(projectResearchPlan);
        }

        // GET: ProjectResearchPlans/Create
        public IActionResult Create()
        {
            ViewData["ProjectStepsId"] = new SelectList(_context.Set<ProjectSteps>(), "Id", "Id");
            ViewData["ReferenceArticlesId"] = new SelectList(_context.Set<ReferenceArticles>(), "Id", "Id");
            ViewData["StepsResearchId"] = new SelectList(_context.Set<StepsResearch>(), "Id", "Id");
            ViewData["WorkItemsId"] = new SelectList(_context.Set<WorkItems>(), "Id", "Id");
            return View();
        }

        // POST: ProjectResearchPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReferenceArticlesId,ProjectStepsId,StepsResearchId,WorkItemsId")] ProjectResearchPlan projectResearchPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectResearchPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectStepsId"] = new SelectList(_context.Set<ProjectSteps>(), "Id", "Id", projectResearchPlan.ProjectStepsId);
            ViewData["ReferenceArticlesId"] = new SelectList(_context.Set<ReferenceArticles>(), "Id", "Id", projectResearchPlan.ReferenceArticlesId);
            ViewData["StepsResearchId"] = new SelectList(_context.Set<StepsResearch>(), "Id", "Id", projectResearchPlan.StepsResearchId);
            ViewData["WorkItemsId"] = new SelectList(_context.Set<WorkItems>(), "Id", "Id", projectResearchPlan.WorkItemsId);
            return View(projectResearchPlan);
        }

        // GET: ProjectResearchPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectResearchPlan = await _context.ProjectResearchPlan.FindAsync(id);
            if (projectResearchPlan == null)
            {
                return NotFound();
            }
            ViewData["ProjectStepsId"] = new SelectList(_context.Set<ProjectSteps>(), "Id", "Id", projectResearchPlan.ProjectStepsId);
            ViewData["ReferenceArticlesId"] = new SelectList(_context.Set<ReferenceArticles>(), "Id", "Id", projectResearchPlan.ReferenceArticlesId);
            ViewData["StepsResearchId"] = new SelectList(_context.Set<StepsResearch>(), "Id", "Id", projectResearchPlan.StepsResearchId);
            ViewData["WorkItemsId"] = new SelectList(_context.Set<WorkItems>(), "Id", "Id", projectResearchPlan.WorkItemsId);
            return View(projectResearchPlan);
        }

        // POST: ProjectResearchPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReferenceArticlesId,ProjectStepsId,StepsResearchId,WorkItemsId")] ProjectResearchPlan projectResearchPlan)
        {
            if (id != projectResearchPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectResearchPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectResearchPlanExists(projectResearchPlan.Id))
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
            ViewData["ProjectStepsId"] = new SelectList(_context.Set<ProjectSteps>(), "Id", "Id", projectResearchPlan.ProjectStepsId);
            ViewData["ReferenceArticlesId"] = new SelectList(_context.Set<ReferenceArticles>(), "Id", "Id", projectResearchPlan.ReferenceArticlesId);
            ViewData["StepsResearchId"] = new SelectList(_context.Set<StepsResearch>(), "Id", "Id", projectResearchPlan.StepsResearchId);
            ViewData["WorkItemsId"] = new SelectList(_context.Set<WorkItems>(), "Id", "Id", projectResearchPlan.WorkItemsId);
            return View(projectResearchPlan);
        }

        // GET: ProjectResearchPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectResearchPlan = await _context.ProjectResearchPlan
                .Include(p => p.ProjectSteps)
                .Include(p => p.ReferenceArticles)
                .Include(p => p.StepsResearch)
                .Include(p => p.WorkItems)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectResearchPlan == null)
            {
                return NotFound();
            }

            return View(projectResearchPlan);
        }

        // POST: ProjectResearchPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectResearchPlan = await _context.ProjectResearchPlan.FindAsync(id);
            _context.ProjectResearchPlan.Remove(projectResearchPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectResearchPlanExists(int id)
        {
            return _context.ProjectResearchPlan.Any(e => e.Id == id);
        }
    }
}

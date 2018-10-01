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
    public class ProjectStepsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ProjectStepsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: ProjectSteps
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectSteps.ToListAsync());
        }

        // GET: ProjectSteps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectSteps = await _context.ProjectSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectSteps == null)
            {
                return NotFound();
            }

            return View(projectSteps);
        }

        // GET: ProjectSteps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlananIslem")] ProjectSteps projectSteps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectSteps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectSteps);
        }

        // GET: ProjectSteps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectSteps = await _context.ProjectSteps.FindAsync(id);
            if (projectSteps == null)
            {
                return NotFound();
            }
            return View(projectSteps);
        }

        // POST: ProjectSteps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlananIslem")] ProjectSteps projectSteps)
        {
            if (id != projectSteps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectSteps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectStepsExists(projectSteps.Id))
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
            return View(projectSteps);
        }

        // GET: ProjectSteps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectSteps = await _context.ProjectSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectSteps == null)
            {
                return NotFound();
            }

            return View(projectSteps);
        }

        // POST: ProjectSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectSteps = await _context.ProjectSteps.FindAsync(id);
            _context.ProjectSteps.Remove(projectSteps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectStepsExists(int id)
        {
            return _context.ProjectSteps.Any(e => e.Id == id);
        }
    }
}

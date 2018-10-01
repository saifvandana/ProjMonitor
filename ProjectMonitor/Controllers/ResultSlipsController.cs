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
    public class ResultSlipsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ResultSlipsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: ResultSlips
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResultSlip.ToListAsync());
        }

        // GET: ResultSlips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultSlip = await _context.ResultSlip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultSlip == null)
            {
                return NotFound();
            }

            return View(resultSlip);
        }

        // GET: ResultSlips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResultSlips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Link")] ResultSlip resultSlip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultSlip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultSlip);
        }

        // GET: ResultSlips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultSlip = await _context.ResultSlip.FindAsync(id);
            if (resultSlip == null)
            {
                return NotFound();
            }
            return View(resultSlip);
        }

        // POST: ResultSlips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Link")] ResultSlip resultSlip)
        {
            if (id != resultSlip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultSlip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultSlipExists(resultSlip.Id))
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
            return View(resultSlip);
        }

        // GET: ResultSlips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultSlip = await _context.ResultSlip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultSlip == null)
            {
                return NotFound();
            }

            return View(resultSlip);
        }

        // POST: ResultSlips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultSlip = await _context.ResultSlip.FindAsync(id);
            _context.ResultSlip.Remove(resultSlip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultSlipExists(int id)
        {
            return _context.ResultSlip.Any(e => e.Id == id);
        }
    }
}

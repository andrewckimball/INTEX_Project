using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTEXII_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace INTEXII_App.Controllers
{
    public class BiologicalSampleController : Controller
    {
        private readonly BYU_ExcavationContext _context;

        public BiologicalSampleController(BYU_ExcavationContext context)
        {
            _context = context;
        }

        // GET: BiologicalSample
        public async Task<IActionResult> Index()
        {
            var bYU_ExcavationContext = _context.BiologicalSamples.Include(b => b.Burial);
            return View(await bYU_ExcavationContext.ToListAsync());
        }

        // GET: BiologicalSample/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologicalSample = await _context.BiologicalSamples
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BiologicalSampleId == id);
            if (biologicalSample == null)
            {
                return NotFound();
            }

            return View(biologicalSample);
        }

        // GET: BiologicalSample/Create
        [Authorize(Roles = "Admin,Researcher")]
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId");
            return View();
        }

        // POST: BiologicalSample/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiologicalSampleId,BurialId,Description,SampleRack,SampleBag,PreviouslySampled,Initials")] BiologicalSample biologicalSample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biologicalSample);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", biologicalSample.BurialId);
            return View(biologicalSample);
        }

        // GET: BiologicalSample/Edit/5
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologicalSample = await _context.BiologicalSamples.FindAsync(id);
            if (biologicalSample == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", biologicalSample.BurialId);
            return View(biologicalSample);
        }

        // POST: BiologicalSample/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal id, [Bind("BiologicalSampleId,BurialId,Description,SampleRack,SampleBag,PreviouslySampled,Initials")] BiologicalSample biologicalSample)
        {
            if (id != biologicalSample.BiologicalSampleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biologicalSample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiologicalSampleExists(biologicalSample.BiologicalSampleId))
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
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", biologicalSample.BurialId);
            return View(biologicalSample);
        }

        // GET: BiologicalSample/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologicalSample = await _context.BiologicalSamples
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BiologicalSampleId == id);
            if (biologicalSample == null)
            {
                return NotFound();
            }

            return View(biologicalSample);
        }

        // POST: BiologicalSample/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var biologicalSample = await _context.BiologicalSamples.FindAsync(id);
            _context.BiologicalSamples.Remove(biologicalSample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiologicalSampleExists(decimal id)
        {
            return _context.BiologicalSamples.Any(e => e.BiologicalSampleId == id);
        }
    }
}

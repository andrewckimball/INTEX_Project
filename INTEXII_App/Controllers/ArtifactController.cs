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
    //testing line 13 for authorization...
    [Authorize]
    public class ArtifactController : Controller
    {
        private readonly BYU_Excavation_2Context _context;

        public ArtifactController(BYU_Excavation_2Context context)
        {
            _context = context;
        }

        // GET: Artifact
        public async Task<IActionResult> Index()
        {
            var bYU_Excavation_2Context = _context.Artifacts.Include(a => a.Area).Include(a => a.QuadrantCardinality);
            return View(await bYU_Excavation_2Context.ToListAsync());
        }

        // GET: Artifact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifacts
                .Include(a => a.Area)
                .Include(a => a.QuadrantCardinality)
                .FirstOrDefaultAsync(m => m.ArtifactId == id);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // GET: Artifact/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "EorW");
            ViewData["QuadrantCardinalityId"] = new SelectList(_context.QuadrantCardinalities, "QuadrantCardinalityId", "Cardinality");
            return View();
        }

        // POST: Artifact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtifactId,AreaId,QuadrantCardinalityId,DateFound,PreviouslySampled,BurialDepth,Rack,Bag,BurialNumber")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artifact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "EorW", artifact.AreaId);
            ViewData["QuadrantCardinalityId"] = new SelectList(_context.QuadrantCardinalities, "QuadrantCardinalityId", "Cardinality", artifact.QuadrantCardinalityId);
            return View(artifact);
        }

        // GET: Artifact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifacts.FindAsync(id);
            if (artifact == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "EorW", artifact.AreaId);
            ViewData["QuadrantCardinalityId"] = new SelectList(_context.QuadrantCardinalities, "QuadrantCardinalityId", "Cardinality", artifact.QuadrantCardinalityId);
            return View(artifact);
        }

        // POST: Artifact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtifactId,AreaId,QuadrantCardinalityId,DateFound,PreviouslySampled,BurialDepth,Rack,Bag,BurialNumber")] Artifact artifact)
        {
            if (id != artifact.ArtifactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artifact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtifactExists(artifact.ArtifactId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "EorW", artifact.AreaId);
            ViewData["QuadrantCardinalityId"] = new SelectList(_context.QuadrantCardinalities, "QuadrantCardinalityId", "Cardinality", artifact.QuadrantCardinalityId);
            return View(artifact);
        }

        // GET: Artifact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifacts
                .Include(a => a.Area)
                .Include(a => a.QuadrantCardinality)
                .FirstOrDefaultAsync(m => m.ArtifactId == id);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // POST: Artifact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artifact = await _context.Artifacts.FindAsync(id);
            _context.Artifacts.Remove(artifact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtifactExists(int id)
        {
            return _context.Artifacts.Any(e => e.ArtifactId == id);
        }
    }
}

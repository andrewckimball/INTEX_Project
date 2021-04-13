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
    public class ArtifactController : Controller
    {
        private readonly BYU_ExcavationContext _context;

        public ArtifactController(BYU_ExcavationContext context)
        {
            _context = context;
        }

        // GET: Artifact
        public async Task<IActionResult> Index()
        {
            var bYU_ExcavationContext = _context.Artifacts.Include(a => a.Burial);
            return View(await bYU_ExcavationContext.ToListAsync());
        }

        // GET: Artifact/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifacts
                .Include(a => a.Burial)
                .FirstOrDefaultAsync(m => m.ArtifactId == id);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // GET: Artifact/Create
        [Authorize(Roles = "Admin,Researcher")]
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId");
            return View();
        }

        // POST: Artifact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtifactId,BurialId,Description")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artifact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", artifact.BurialId);
            return View(artifact);
        }

        // GET: Artifact/Edit/5
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal? id)
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
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", artifact.BurialId);
            return View(artifact);
        }

        // POST: Artifact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal id, [Bind("ArtifactId,BurialId,Description")] Artifact artifact)
        {
            if (id != artifact.ArtifactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Artifacts.Where(e => e.ArtifactId == id).FirstOrDefault().Description = artifact.Description;
                    //_context.Artifacts.Where(e => e.ArtifactId == id).FirstOrDefault().Description = artifact.;

                    //_context.Update(artifact);
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
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", artifact.BurialId);
            return View(artifact);
        }

        // GET: Artifact/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = await _context.Artifacts
                .Include(a => a.Burial)
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var artifact = await _context.Artifacts.FindAsync(id);
            _context.Artifacts.Remove(artifact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtifactExists(decimal id)
        {
            return _context.Artifacts.Any(e => e.ArtifactId == id);
        }
    }
}

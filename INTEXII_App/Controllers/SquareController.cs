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
    public class SquareController : Controller
    {
        private readonly BYU_ExcavationContext _context;

        public SquareController(BYU_ExcavationContext context)
        {
            _context = context;
        }

        // GET: Square
        public async Task<IActionResult> Index()
        {
            return View(await _context.Squares.ToListAsync());
        }

        // GET: Square/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var square = await _context.Squares
                .FirstOrDefaultAsync(m => m.SquareId == id);
            if (square == null)
            {
                return NotFound();
            }

            return View(square);
        }

        // GET: Square/Create
        [Authorize(Roles = "Admin,Researcher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Square/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Researcher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SquareId,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialLocationNs,BurialLocationEw")] Square square)
        {
            if (ModelState.IsValid)
            {
                _context.Add(square);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(square);
        }

        // GET: Square/Edit/5
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var square = await _context.Squares.FindAsync(id);
            if (square == null)
            {
                return NotFound();
            }
            return View(square);
        }

        // POST: Square/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Researcher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("SquareId,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialLocationNs,BurialLocationEw")] Square square)
        {
            if (id != square.SquareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Updating the square
                    _context.Squares.Where(e => e.SquareId == id).FirstOrDefault().LowPairNs = square.LowPairNs;
                    _context.Squares.Where(e => e.SquareId == id).FirstOrDefault().HighPairNs = square.HighPairNs;
                    _context.Squares.Where(e => e.SquareId == id).FirstOrDefault().LowPairEw = square.LowPairEw;
                    _context.Squares.Where(e => e.SquareId == id).FirstOrDefault().HighPairEw = square.HighPairEw;
                    _context.Squares.Where(e => e.SquareId == id).FirstOrDefault().BurialLocationNs = square.BurialLocationNs;
                    _context.Squares.Where(e => e.SquareId == id).FirstOrDefault().BurialLocationEw = square.BurialLocationEw;

                    //_context.Update(square);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SquareExists(square.SquareId))
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
            return View(square);
        }

        // GET: Square/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var square = await _context.Squares
                .FirstOrDefaultAsync(m => m.SquareId == id);
            if (square == null)
            {
                return NotFound();
            }

            return View(square);
        }

        // POST: Square/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var square = await _context.Squares.FindAsync(id);
            _context.Squares.Remove(square);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SquareExists(decimal id)
        {
            return _context.Squares.Any(e => e.SquareId == id);
        }
    }
}

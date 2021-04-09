using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTEXII_App.Models;

namespace INTEXII_App.Controllers
{
    public class BurialController : Controller
    {
        private readonly BYU_ExcavationContext _context;

        public BurialController(BYU_ExcavationContext context)
        {
            _context = context;
        }

        // GET: Burial
        public async Task<IActionResult> Index()
        {
            var bYU_ExcavationContext = _context.Burials.Take(10).Include(b => b.Area).Include(b => b.Square);  /////////////////////// .Take(10) only returns the first 10 rows/////////////////////
            return View(await bYU_ExcavationContext.ToListAsync());
        }

        // GET: Burial/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burials
                .Include(b => b.Area)
                .Include(b => b.Square)
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // GET: Burial/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Area1");
            ViewData["SquareId"] = new SelectList(_context.Squares, "SquareId", "BurialLocationEw");
            return View();
        }

        // POST: Burial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialId,SquareId,AreaId,BurialNumber,SouthToHead,SouthToFeet,WestToHead,WestToFeet,Length,Depth,PhotoTaken,BurialGoods,DateFound,ClusterNumber,SampleNumber,Rack,Shelf,Bag,PreviouslySampled,SexBody,SexGiles,GeFunctionTotal,Description,BasilarSuture,VentralArc,SubPubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpramus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,MedialClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,DecimalerorbitalBreadth,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimatedAge,AgeMethod,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,HeadDirection,Byusample,BodyAnalysisYear,SkullAtMagazine,PostcraniaAtMagazine,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribiaOrbitala,PoroticHyperotosis,PoroticHyperotosisLocations,MetopicSuture,ButtonOsteoma,OsteologyUnknownComment,TmjOa,LinearHypoplasiaEnamel,AreaHillBurials,Tomb,BurialPreservation,BurialWrapping,BurialAdultChild,GenderCode,BurialGenderMethod,AgeCodeSingle,FaceBundle,DateOnSkull")] Burial burial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Area1", burial.AreaId);
            ViewData["SquareId"] = new SelectList(_context.Squares, "SquareId", "BurialLocationEw", burial.SquareId);
            return View(burial);
        }

        // GET: Burial/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burials.FindAsync(id);
            if (burial == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Area1", burial.AreaId);
            ViewData["SquareId"] = new SelectList(_context.Squares, "SquareId", "BurialLocationEw", burial.SquareId);
            return View(burial);
        }

        // POST: Burial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("BurialId,SquareId,AreaId,BurialNumber,SouthToHead,SouthToFeet,WestToHead,WestToFeet,Length,Depth,PhotoTaken,BurialGoods,DateFound,ClusterNumber,SampleNumber,Rack,Shelf,Bag,PreviouslySampled,SexBody,SexGiles,GeFunctionTotal,Description,BasilarSuture,VentralArc,SubPubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpramus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,MedialClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,DecimalerorbitalBreadth,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimatedAge,AgeMethod,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,HeadDirection,Byusample,BodyAnalysisYear,SkullAtMagazine,PostcraniaAtMagazine,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribiaOrbitala,PoroticHyperotosis,PoroticHyperotosisLocations,MetopicSuture,ButtonOsteoma,OsteologyUnknownComment,TmjOa,LinearHypoplasiaEnamel,AreaHillBurials,Tomb,BurialPreservation,BurialWrapping,BurialAdultChild,GenderCode,BurialGenderMethod,AgeCodeSingle,FaceBundle,DateOnSkull")] Burial burial)
        {
            if (id != burial.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialExists(burial.BurialId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Area1", burial.AreaId);
            ViewData["SquareId"] = new SelectList(_context.Squares, "SquareId", "BurialLocationEw", burial.SquareId);
            return View(burial);
        }

        // GET: Burial/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burials
                .Include(b => b.Area)
                .Include(b => b.Square)
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // POST: Burial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var burial = await _context.Burials.FindAsync(id);
            _context.Burials.Remove(burial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialExists(decimal id)
        {
            return _context.Burials.Any(e => e.BurialId == id);
        }
    }
}

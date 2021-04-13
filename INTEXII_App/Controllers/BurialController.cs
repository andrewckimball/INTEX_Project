using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTEXII_App.Models;
using INTEXII_App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace INTEXII_App.Controllers
{
    public class BurialController : Controller
    {
        private readonly BYU_ExcavationContext _context;

        public BurialController(BYU_ExcavationContext context)
        {
            _context = context;
        }

        // Number of records to display per page
        private int PageSize = 50;

        //List<int> square = _context.Squares.Select(p => p.SquareId).Distinct().ToList();

        // GET: Burial
        public async Task<IActionResult> Index(string id, int page = 1)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;

            // Drop down options for filters
            List<string> squareIds = new List<string>();

            foreach (Square s in _context.Squares.Distinct().ToList())
            {
                string squareId = s.LowPairNs.ToString() + '/' + s.HighPairNs.ToString() + ' ' + s.BurialLocationNs.ToString() + ' ' + s.LowPairEw.ToString() + '/' + s.HighPairEw.ToString() + ' ' + s.BurialLocationEw.ToString();
                squareIds.Add(squareId);
            }

            ViewBag.Square = _context.Squares.Distinct().ToList();
            ViewBag.Area = new List<string> {"NE", "NW", "SW", "SE" };
            ViewBag.PhotoTaken = new List<string> { "true", "false"};
            ViewBag.BurialGoods = new List<string> { "true", "false" };
            ViewBag.Sex = new List<string> { "U", "F", "M", "S" };
            ViewBag.HairColor = new List<string> { "Blonde", "Red Brown", "Light Brown", "Brown", "Red", "Black", "Dark Brown"};
            ViewBag.FaceBundle = new List<string> { "U", "Y" };
            ViewBag.HeadDirection = new List<string> { "E", "I", "U", "W"};
            ViewBag.EstimatedAge = _context.Burials.Select(p => p.EstimatedAge).Distinct().ToList();

            BurialListViewModel burialListViewModel = new BurialListViewModel
            {
                Areas = _context.Areas,
                Squares = _context.Squares,
                Burials =  _context.Burials,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _context.Burials.Count()
                    //TotalNumItems = category == null ? _context.Burials.Count() : _context.Burials.Where(x => x.Type == category).Count()/
                }
            };

            // Filter context based on filters
            if (filters.HasSquare)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.SquareId == Convert.ToDecimal(filters.Square));
            }

            if (filters.HasArea)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.AreaId == burialListViewModel.Areas.Where(x => x.Area1 == filters.Area).FirstOrDefault().AreaId);
            }

            if (filters.HasMinLength)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.Length >= Convert.ToDecimal(filters.MinLength));
            }

            if (filters.HasMaxLength)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.Length <= Convert.ToDecimal(filters.MaxLength));
            }

            if (filters.HasMinDepth)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.Depth >= Convert.ToDecimal(filters.MinDepth));
            }

            if (filters.HasMaxDepth)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.Depth <= Convert.ToDecimal(filters.MaxDepth));
            }

            if (filters.HasPhotoTaken)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.PhotoTaken == Convert.ToBoolean(filters.PhotoTaken));
            }
            if (filters.HasBurialGoods)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.BurialGoods == Convert.ToBoolean(filters.BurialGoods));
            }

            if (filters.HasSex)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.SexBody == filters.Sex);
            }

            if (filters.HasHairColor)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.HairColor == filters.HairColor);
            }

            if (filters.HasFaceBundle)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.FaceBundle == filters.FaceBundle);
            }

            if (filters.HasHeadDirection)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.HeadDirection == filters.HeadDirection);
            }
            if (filters.HasEstimatedAge)
            {
                burialListViewModel.Burials = burialListViewModel.Burials.Where(t => t.EstimatedAge == filters.EstimatedAge);
            }

            burialListViewModel.Burials = burialListViewModel.Burials.Skip((page - 1) * PageSize).Take(PageSize);
            return View("Index", burialListViewModel);
        }


        // Filter
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
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

            return View(new DetailListViewModel
            {
                DetailBurial = burial,
                Burials = _context.Burials

            });
        }

        // GET: Burial/Create
        [Authorize(Roles = "Admin,Researcher")]
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
        [Authorize(Roles = "Admin,Researcher")]
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
        [Authorize(Roles = "Admin,Researcher")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTEXII_App.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using INTEXII_App.Models.ViewModels;

namespace INTEXII_App.Controllers
{
    public class ImageController : Controller
    {
        private readonly BYU_ExcavationContext _context;

        public ImageController(BYU_ExcavationContext context)
        {
            _context = context;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            var bYU_ExcavationContext = _context.Images.Include(i => i.Burial);
            return View(await bYU_ExcavationContext.ToListAsync());
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return RedirectToAction("Details", "Burial", new { ID = id });
        }

        // GET: Image/Create
        [Authorize(Roles = "Admin,Researcher")]
        public IActionResult Create(decimal id)
        {
            ViewBag.burialid = id;
            //ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId");
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Create(ImageUploadViewModel viewModel)
        {

            string objectKey = $"Burials/{viewModel.fileForm.FileName}-{DateTime.Now.ToString()}";


            Image img = new Image
            {
                BurialId = Convert.ToDecimal(viewModel.BurialId),
                ImagePodecimaler = S3Upload.GeneratePreSignedURL(objectKey),
                Burial = _context.Burials.Where(x => x.BurialId == Convert.ToDecimal(viewModel.BurialId)).FirstOrDefault()
            };

            if (ModelState.IsValid)
            {
                _context.Add(img);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", img.BurialId);
            
<<<<<<< HEAD
            using (var memoryStream = new MemoryStream())
            {
                await viewModel.fileForm.CopyToAsync(memoryStream);
                // Upload the file if less than 2 MB
                if (memoryStream.Length < 10485760)
                {
                    await S3Upload.UploadFileAsync(memoryStream, "arn:aws:s3:us-east-1:524546685232:accesspoint/is410", objectKey);
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
=======
            using (var memoryStream = new MemoryStream())
            {
                await viewModel.fileForm.CopyToAsync(memoryStream);
                // Upload the file if less than 10 MB
                if (memoryStream.Length < 10485760)
                {
                    await S3Upload.UploadFileAsync(memoryStream, "arn:aws:s3:us-east-1:524546685232:accesspoint/is410", objectKey);
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
>>>>>>> eafb95201bf33ccfb4f736ce7dbd85b483ab0f6e
            }

            return RedirectToAction("Details", "Burial", new { ID = viewModel.BurialId });
            

        }

        // GET: Image/Edit/5
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", image.BurialId);
            return View(image);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Researcher")]
        public async Task<IActionResult> Edit(decimal id, [Bind("ImageId,BurialId,ImagePodecimaler")] Image image)
        {
            if (id != image.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ImageId))
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
            ViewData["BurialId"] = new SelectList(_context.Burials, "BurialId", "BurialId", image.BurialId);
            return View(image);
        }

        // GET: Image/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(i => i.Burial)
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var image = await _context.Images.FindAsync(id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(decimal id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }

        public IActionResult ViewImages()
        {
            return View();
        }
    }
}

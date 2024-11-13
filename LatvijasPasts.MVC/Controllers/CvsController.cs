using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatvijasPasts.Core.Models;
using LatvijasPasts.Data;

namespace LatvijasPasts.MVC.Controllers
{
    public class CvsController : Controller
    {
        private readonly LPDbContext _context;

        public CvsController(LPDbContext context)
        {
            _context = context;
        }

        // GET: Cvs
        public IActionResult Index()
        {
            var cvs = _context.CVs.Include(x=>x.PersonalData).ToList();

            return View(cvs);
        }

        // GET: Cvs/Details/5
        [Route("Cvs/Details/{id}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = _context.CVs
                .Include(x=>x.PersonalData)
                .Include(x=>x.Address)
                .Include(x=>x.Educations)
                .Include(x=>x.WorkExperiences)
                .FirstOrDefault(m => m.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // GET: Cvs/Create
        public IActionResult Create()
        {
            var cv = new Cv();
            cv.Educations = new List<Education>() { new Education() };
            cv.WorkExperiences = new List<WorkExperience>() { new WorkExperience() };

            return View(cv);
        }

        // POST: Cvs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id")] Cv cv)
        {
            if (ModelState.IsValid)
            {
                _context.CVs.Add(cv);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(cv);
        }

        // GET: Cvs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = _context.CVs
                .Include(x => x.Educations)
                .Include(x => x.Address)
                .Include(x => x.PersonalData)
                .Include(x => x.WorkExperiences)
                .FirstOrDefault(x => x.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // POST: Cvs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Cv cv)
        {
            if (id != cv.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvExists(cv.Id))
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
            return View(cv);
        }

        // GET: Cvs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.CVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // POST: Cvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cv =  _context.CVs
                .Include(x=>x.PersonalData)
                .Include(x => x.WorkExperiences)
                .Include(x => x.Educations)
                .Include(x => x.Address)
                .FirstOrDefault(x=>x.Id == id);
            if (cv != null)
            {
                _context.Educations.RemoveRange(cv.Educations);
                _context.WorkExperiences.RemoveRange(cv.WorkExperiences);
                _context.CVs.Remove(cv);
            }

             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CvExists(int id)
        {
            return _context.CVs.Any(e => e.Id == id);
        }
    }
}

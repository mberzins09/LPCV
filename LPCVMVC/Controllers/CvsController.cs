using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LPCVMVC.Data;
using LatvijasPasts.Core.Models;

namespace LPCVMVC.Controllers
{
    public class CvsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CvsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult EditPersonalData(int CvId) => RedirectToAction("EditPersonalData", "PersonalDatas", new { CvId });
        public IActionResult EditAddress(int CvId) => RedirectToAction("EditAddress", "Addresses", new { CvId });
        public IActionResult EditEducation(int CvId) => RedirectToAction("EditEducation", "Educations", new { CvId });
        public IActionResult EditWorkExperience(int CvId) => RedirectToAction("EditWorkExperiences", "WorkExperience", new { CvId });
        // GET: Cvs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CVs.ToListAsync());
        }

        // GET: Cvs/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Cvs/Create
        public async Task<IActionResult> Create()
        {
            Cv cv = new Cv
            {
                PersonalData = new PersonalData(),
                Address = new Address(),
                Education = new Education(),
                WorkExperience = new WorkExperience()
            };
            _context.Add(cv);
            await _context.SaveChangesAsync();
            cv.PersonalData.CvId = cv.Id;
            cv.Address.CvId = cv.Id;
            cv.Education.CvId = cv.Id;
            cv.WorkExperience.CvId = cv.Id;


            return View(cv);
        }

        // POST: Cvs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Cv cv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cv);
        }

        // GET: Cvs/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? CvId)
        {
            if (CvId == null)
            {
                return NotFound();
            }

            var cv = await _context.CVs.FirstOrDefaultAsync(x=> x.Id == CvId);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }

        // POST: Cvs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int CvId, [Bind("Id")] Cv cv)
        {
            if (CvId != cv.Id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cv = await _context.CVs.FindAsync(id);
            if (cv != null)
            {
                _context.CVs.Remove(cv);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvExists(int id)
        {
            return _context.CVs.Any(e => e.Id == id);
        }

    }
}

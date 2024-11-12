using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatvijasPastsMVC.Database;
using LatvijasPastsMVC.Models;

namespace LatvijasPastsMVC.Controllers
{
    public class CVController : Controller
    {
        private readonly LPDbContext _context;

        public CVController(LPDbContext context)
        {
            _context = context;
        }

        // GET: CV
        public async Task<IActionResult> Index()
        {
            var cvs = await _context.CVs
                .ToListAsync();

            return View(cvs);
        }

        // GET: CV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.CVs
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // GET: CV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CV cV)
        {
            if (ModelState.IsValid)
            {
                _context.CVs.Add(cV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cV);
        }

        // GET: CV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CVs.FindAsync(id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // POST: CV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,Email")] CV cV)
        {
            if (id != cV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.CVs.Update(cV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVExists(cV.Id))
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
            return View(cV);
        }

        // GET: CV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // POST: CV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cV = await _context.CVs.FindAsync(id);
            if (cV != null)
            {
                _context.CVs.Remove(cV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVExists(int id)
        {
            return _context.CVs.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LPCVMVC.Data;
using LatvijasPasts.Core.Models;

namespace LPCVMVC.Controllers
{
    public class PersonalDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirsName,LastName,Phone,Email,Id")] PersonalData data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }
        // GET: PersonalDatas/Edit/5
        public async Task<IActionResult> EditPersonalData(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalData = await _context.PersonalData.FindAsync(id);
            if (personalData == null)
            {
                return NotFound();
            }

            return View(personalData);
        }

        // POST: PersonalDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPersonalData(int id, [Bind("FirstName,LastName,Phone,Email,Id")] PersonalData personalData)
        {
            if (id != personalData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalDataExists(personalData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "Cv", new { id = personalData.CvId });
            }

            return View(personalData);
        }

        // GET: PersonalDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalData = await _context.PersonalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalData == null)
            {
                return NotFound();
            }

            return View(personalData);
        }

        // POST: PersonalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalData = await _context.PersonalData.FindAsync(id);
            if (personalData != null)
            {
                _context.PersonalData.Remove(personalData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalDataExists(int id)
        {
            return _context.PersonalData.Any(e => e.Id == id);
        }
    }
}

using AlgebraPredbiljezbeApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlgebraPredbiljezbeApp.Controllers
{
    public class PredbiljezbaController : Controller
    {
        ApplicationDbContext _context { get; set; }

        public PredbiljezbaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Predbiljezba
        public async Task<IActionResult> Index()
        {
            return View(await _context.Predbiljezba.Include(x => x.Seminar).ToListAsync());
        }

        // GET: Predbiljezba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predbiljezba = await _context.Predbiljezba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (predbiljezba == null)
            {
                return NotFound();
            }

            return View(predbiljezba);
        }

        // GET: Predbiljezba/Create
        public IActionResult Create()
        {
            PopulateSeminarDropDownList();
            return View();
        }

        // POST: Predbiljezba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Ime,Prezime,Adresa,Email,Telefon,SeminarId,Status")] Predbiljezba predbiljezba)
        {
            //PopulateSeminarDropDownList(_context, predbiljezba.SeminarId);

            if (ModelState.IsValid)
            {
                _context.Add(predbiljezba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predbiljezba);
        }

        // GET: Predbiljezba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predbiljezba = await _context.Predbiljezba.Include(x => x.Seminar).Where(x => x.Id == id.Value).SingleOrDefaultAsync();
            if (predbiljezba == null)
            {
                return NotFound();
            }

            return View(predbiljezba);
        }

        // POST: Predbiljezba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Ime,Prezime,Adresa,Email,Telefon,SeminarId,Status")] Predbiljezba predbiljezba)
        {
            if (id != predbiljezba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predbiljezba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredbiljezbaExists(predbiljezba.Id))
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
            return View(predbiljezba);
        }

        // GET: Predbiljezba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predbiljezba = await _context.Predbiljezba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (predbiljezba == null)
            {
                return NotFound();
            }

            return View(predbiljezba);
        }

        // POST: Predbiljezba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predbiljezba = await _context.Predbiljezba.FindAsync(id);
            _context.Predbiljezba.Remove(predbiljezba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredbiljezbaExists(int id)
        {
            return _context.Predbiljezba.Any(e => e.Id == id);
        }

        private void PopulateSeminarDropDownList(object odabraniSeminar = null)
        {
            var departmentsQuery = from d in _context.Seminar
                                   orderby d.Naziv
                                   select d;
            ViewBag.SeminarId = new SelectList(departmentsQuery.AsNoTracking(), "Id", "Naziv", odabraniSeminar);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlgebraPredbiljezbeApp.Models;
using AlgebraPredbiljezbeApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AlgebraPredbiljezbeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly aspnetAlgebraPredbiljezbeAppD8A763C64D0E4A4EBB4118DBF6243A5DContext _context;

        public string Username { get; set; }

        public HomeController(aspnetAlgebraPredbiljezbeAppD8A763C64D0E4A4EBB4118DBF6243A5DContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string naziv)
        {
            return View(await _context.Seminar.Where(x => x.Naziv.Contains(naziv) || naziv == null).ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Odaberi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminar.FindAsync(id);
            if (seminar == null)
            {
                return NotFound();
            }

            Predbiljezba predbiljezba = new Predbiljezba();
            predbiljezba.SeminarId = id;
            predbiljezba.Seminar = seminar;

            return View(predbiljezba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Ime,Prezime,Adresa,Email,Telefon,SeminarId,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                predbiljezba.Datum = DateTime.Now;

                _context.Add(predbiljezba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predbiljezba);
        }
    }
}

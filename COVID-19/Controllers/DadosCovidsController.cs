using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COVID19.Models;
using COVID_19.Data;
using Microsoft.AspNetCore.Authorization;

namespace COVID_19.Controllers
{
    public class DadosCovidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosCovidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadoCovids
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DadosCovid.Include(d => d.pais);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DadoCovids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoCovid = await _context.DadosCovid
                .Include(d => d.pais)
                .FirstOrDefaultAsync(m => m.id == id);
            if (dadoCovid == null)
            {
                return NotFound();
            }

            return View(dadoCovid);
        }

        [Authorize]
        // GET: DadoCovids/Create
        public IActionResult Create()
        {
            ViewData["paisId"] = new SelectList(_context.Paises, "idPais", "nomePais");
            return View();
        }

        // POST: DadoCovids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,mortes,confirmados,recuperados,paisId")] DadoCovid dadoCovid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadoCovid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["paisId"] = new SelectList(_context.Paises, "idPais", "nomePais", dadoCovid.paisId);
            return View(dadoCovid);
        }

        [Authorize]
        // GET: DadoCovids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoCovid = await _context.DadosCovid.FindAsync(id);
            if (dadoCovid == null)
            {
                return NotFound();
            }
            ViewData["paisId"] = new SelectList(_context.Paises, "idPais", "nomePais", dadoCovid.paisId);
            return View(dadoCovid);
        }

        // POST: DadoCovids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,mortes,confirmados,recuperados,paisId")] DadoCovid dadoCovid)
        {
            if (id != dadoCovid.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadoCovid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadoCovidExists(dadoCovid.id))
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
            ViewData["paisId"] = new SelectList(_context.Paises, "idPais", "nomePais", dadoCovid.paisId);
            return View(dadoCovid);
        }

        [Authorize]
        // GET: DadoCovids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoCovid = await _context.DadosCovid
                .Include(d => d.pais)
                .FirstOrDefaultAsync(m => m.id == id);
            if (dadoCovid == null)
            {
                return NotFound();
            }

            return View(dadoCovid);
        }

        // POST: DadoCovids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadoCovid = await _context.DadosCovid.FindAsync(id);
            _context.DadosCovid.Remove(dadoCovid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadoCovidExists(int id)
        {
            return _context.DadosCovid.Any(e => e.id == id);
        }
    }
}

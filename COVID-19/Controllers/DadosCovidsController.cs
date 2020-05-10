using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COVID19.Models;
using COVID_19.Data;

namespace COVID_19.Controllers
{
    public class DadosCovidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosCovidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadosCovids
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DadosCovid.Include(d => d.Paises);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DadosCovids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoCovid = await _context.DadosCovid
                .Include(d => d.Paises)
                .FirstOrDefaultAsync(m => m.id == id);
            if (dadoCovid == null)
            {
                return NotFound();
            }

            return View(dadoCovid);
        }

        // GET: DadosCovids/Create
        public IActionResult Create()
        {
            ViewData["PaisesId"] = new SelectList(_context.Paises, "id", "id");
            return View();
        }

        // POST: DadosCovids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,PaisesId")] DadoCovid dadoCovid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadoCovid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisesId"] = new SelectList(_context.Paises, "id", "id", dadoCovid.PaisesId);
            return View(dadoCovid);
        }

        // GET: DadosCovids/Edit/5
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
            ViewData["PaisesId"] = new SelectList(_context.Paises, "id", "id", dadoCovid.PaisesId);
            return View(dadoCovid);
        }

        // POST: DadosCovids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,PaisesId")] DadoCovid dadoCovid)
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
            ViewData["PaisesId"] = new SelectList(_context.Paises, "id", "id", dadoCovid.PaisesId);
            return View(dadoCovid);
        }

        // GET: DadosCovids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoCovid = await _context.DadosCovid
                .Include(d => d.Paises)
                .FirstOrDefaultAsync(m => m.id == id);
            if (dadoCovid == null)
            {
                return NotFound();
            }

            return View(dadoCovid);
        }

        // POST: DadosCovids/Delete/5
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

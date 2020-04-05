using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class RegionesController : Controller
    {
        private readonly PokedexContext _context;

        public RegionesController(PokedexContext context)
        {
            _context = context;
        }

        // GET: Regiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regiones.ToListAsync());
        }

        // GET: Regiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones
                .FirstOrDefaultAsync(m => m.RegId == id);
            if (regiones == null)
            {
                return NotFound();
            }

            return View(regiones);
        }

        // GET: Regiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegId,NombreR")] Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiones);
        }

        // GET: Regiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return NotFound();
            }
            return View(regiones);
        }

        // POST: Regiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegId,NombreR")] Regiones regiones)
        {
            if (id != regiones.RegId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionesExists(regiones.RegId))
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
            return View(regiones);
        }

        // GET: Regiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones
                .FirstOrDefaultAsync(m => m.RegId == id);
            if (regiones == null)
            {
                return NotFound();
            }

            return View(regiones);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiones = await _context.Regiones.FindAsync(id);
            _context.Regiones.Remove(regiones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionesExists(int id)
        {
            return _context.Regiones.Any(e => e.RegId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_com_EF_Core.Models;

namespace MVC_CRUD_com_EF_Core.Controllers
{
    public class EmpregadoController : Controller
    {
        private readonly EmpregadoContext _context;

        public EmpregadoController(EmpregadoContext context)
        {
            _context = context;
        }

        // GET: Empregado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregados.ToListAsync());
        }

        // GET: Empregado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
        }

        // GET: Empregado/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Empregado());
            else
                return View(_context.Empregados.Find(id));
        }

        // POST: Empregado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmpregadoId,NomeCompleto,EmpCode,Cargo,LocalTrabalho")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                if(empregado.EmpregadoId == 0)
                    _context.Add(empregado);
                else
                    _context.Update(empregado);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empregado);
        }

        // GET: Empregado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados.FindAsync(id);
            if (empregado == null)
            {
                return NotFound();
            }
            return View(empregado);
        }

        // POST: Empregado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpregadoId,NomeCompleto,EmpCode,Cargo,LocalTrabalho")] Empregado empregado)
        {
            if (id != empregado.EmpregadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadoExists(empregado.EmpregadoId))
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
            return View(empregado);
        }

        // GET: Empregado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
			var empregado = await _context.Empregados.FindAsync(id);
            _context.Empregados.Remove(empregado);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Empregado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);
            _context.Empregados.Remove(empregado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadoExists(int id)
        {
            return _context.Empregados.Any(e => e.EmpregadoId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pratice_EF_Core.Models;
using static Pratice_EF_Core.Helper;

namespace Pratice_EF_Core.Controllers
{
    [Authorize] // Bloqueia se não estiver logado
    public class CarroController : Controller
    {
        private readonly CarroContext _context;

        public CarroController(CarroContext context)
        {
            _context = context;
        }

        // GET: Carro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.ToListAsync());
        }

       

        [NoDirectAccess]
        // GET: Carro/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if(id==0)
                return View(new Carro());
            else
			{
                var carro = await _context.Carros.FindAsync(id);

                if (carro == null)
                    return NotFound();


                return View(carro);
			}
        }

        //POST: Carro/AddOrEdit/carro
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddOrEdit([Bind("CarroId,Valor,Nome")] Carro carro)
		{
			if (ModelState.IsValid)
			{
				if (carro.CarroId == 0)
				{
                    _context.Add(carro);
                    await _context.SaveChangesAsync();
                }
				else
				{
					try
					{
                        _context.Update(carro);
                        await _context.SaveChangesAsync();
                    }
					catch (DbUpdateConcurrencyException)
					{

                        if (!CarroExists(carro.CarroId))
                            return NotFound();
                        else
                            throw;
					}
                }

                return Json(new
                {
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Carros.ToList())
                });
			}
            return Json(new
            {
                isValid = false,
                html = Helper.RenderRazorViewToString(this, "AddOrEdit", carro)
            });
        }



		// GET: Carro/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            var carro = await _context.Carros.FindAsync(id);

            _context.Carros.Remove(carro);

            return Json(new
            {
                html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Carros.ToList())
            });
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            
            return Json(new
            {
                html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Carros.ToList())
            });
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.CarroId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETcoreMVCHW.Data;
using ASPNETcoreMVCHW.Models;

namespace ASPNETcoreMVCHW.Controllers
{
    public class CakeRecipesController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public CakeRecipesController(ApplicationDBcontext context)
        {
            _context = context;
        }

        // GET: CakeRecipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: CakeRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cakeRecipes = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cakeRecipes == null)
            {
                return NotFound();
            }

            return View(cakeRecipes);
        }

        // GET: CakeRecipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CakeRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Recipe")] CakeRecipes cakeRecipes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cakeRecipes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cakeRecipes);
        }

        // GET: CakeRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cakeRecipes = await _context.Recipes.FindAsync(id);
            if (cakeRecipes == null)
            {
                return NotFound();
            }
            return View(cakeRecipes);
        }

        // POST: CakeRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Recipe")] CakeRecipes cakeRecipes)
        {
            if (id != cakeRecipes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cakeRecipes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeRecipesExists(cakeRecipes.Id))
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
            return View(cakeRecipes);
        }

        // GET: CakeRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cakeRecipes = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cakeRecipes == null)
            {
                return NotFound();
            }

            return View(cakeRecipes);
        }

        // POST: CakeRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cakeRecipes = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(cakeRecipes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeRecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}

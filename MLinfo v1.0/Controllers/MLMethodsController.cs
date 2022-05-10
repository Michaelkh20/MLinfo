#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MLinfo_v1._0.Data;
using MLinfo_v1._0.Models.DatabasedModels;
//using MLinfo_v1._0.Models.DBModels;

namespace MLinfo_v1._0.Controllers
{
    public class MLMethodsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MLMethodsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: MLMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.MethodMlinfos.Include(method => method.Articles).ToListAsync());
        }

        // GET: MLMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MLMethod method = await GetMethodFromDB(id);
            if (method == null)
            {
                return NotFound();
            }

            return View(method);
        }


        // GET: MLMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MLMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameE,NameR")] MLMethod method)
        {
            if (ModelState.IsValid)
            {
                _context.MethodMlinfos.Add(method);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(method);
        }

        // GET: MLMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var method = await GetMethodFromDB(id);
            if (method == null)
            {
                return NotFound();
            }
            return View(method);
        }

        // POST: MLMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameE,NameR")] MLMethod method)
        {
            if (id != method.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.MethodMlinfos.Update(method);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MLMethodExists(method.ID))
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
            return View(method);
        }

        // GET: MLMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var method = await GetMethodFromDB(id);
            if (method == null)
            {
                return NotFound();
            }

            return View(method);
        }

        // POST: MLMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var method = await GetMethodFromDB(id);
            _context.MethodMlinfos.Remove(method);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MLMethodExists(int id)
        {
            return _context.MethodMlinfos.Any(e => e.ID == id);
        }

        private async Task<MLMethod> GetMethodFromDB(int? id)
        {
            return await _context.MethodMlinfos.Include(method => method.Articles)
                .FirstOrDefaultAsync(m => m.ID == id);
        }
    }
}

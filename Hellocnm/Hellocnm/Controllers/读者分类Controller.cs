using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hellocnm.Data;
using Hellocnm.Models;

namespace Hellocnm.Controllers
{
    public class 读者分类Controller : Controller
    {
        private readonly HellocnmContext _context;

        public 读者分类Controller(HellocnmContext context)
        {
            _context = context;
        }

        // GET: 读者分类
        public async Task<IActionResult> Index()
        {
            return View(await _context.读者分类.ToListAsync());
        }

        // GET: 读者分类/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 读者分类 = await _context.读者分类
                .FirstOrDefaultAsync(m => m.kind_num == id);
            if (读者分类 == null)
            {
                return NotFound();
            }

            return View(读者分类);
        }

        // GET: 读者分类/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: 读者分类/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kind_num,ID,DictName,LimitNumber,LimitDay")] 读者分类 读者分类)
        {
            if (ModelState.IsValid)
            {
                _context.Add(读者分类);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(读者分类);
        }

        // GET: 读者分类/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 读者分类 = await _context.读者分类.FindAsync(id);
            if (读者分类 == null)
            {
                return NotFound();
            }
            return View(读者分类);
        }

        // POST: 读者分类/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("kind_num,ID,DictName,LimitNumber,LimitDay")] 读者分类 读者分类)
        {
            if (id != 读者分类.kind_num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(读者分类);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!读者分类Exists(读者分类.kind_num))
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
            return View(读者分类);
        }

        // GET: 读者分类/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 读者分类 = await _context.读者分类
                .FirstOrDefaultAsync(m => m.kind_num == id);
            if (读者分类 == null)
            {
                return NotFound();
            }

            return View(读者分类);
        }

        // POST: 读者分类/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var 读者分类 = await _context.读者分类.FindAsync(id);
            _context.读者分类.Remove(读者分类);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool 读者分类Exists(int id)
        {
            return _context.读者分类.Any(e => e.kind_num == id);
        }
    }
}

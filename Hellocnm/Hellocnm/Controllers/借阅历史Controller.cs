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
    public class 借阅历史Controller : Controller
    {
        private readonly HellocnmContext _context;

        public 借阅历史Controller(HellocnmContext context)
        {
            _context = context;
        }

        // GET: 借阅历史
        public async Task<IActionResult> Index()
        {
            return View(await _context.借阅历史.ToListAsync());
        }

        // GET: 借阅历史/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 借阅历史 = await _context.借阅历史
                .FirstOrDefaultAsync(m => m.ID == id);
            if (借阅历史 == null)
            {
                return NotFound();
            }

            return View(借阅历史);
        }

        // GET: 借阅历史/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: 借阅历史/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ReaderCode,BookCode,BorrowDate,ShouldReturnDate,RealReturnDate")] 借阅历史 借阅历史)
        {
            if (ModelState.IsValid)
            {
                _context.Add(借阅历史);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(借阅历史);
        }

        // GET: 借阅历史/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 借阅历史 = await _context.借阅历史.FindAsync(id);
            if (借阅历史 == null)
            {
                return NotFound();
            }
            return View(借阅历史);
        }

        // POST: 借阅历史/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReaderCode,BookCode,BorrowDate,ShouldReturnDate,RealReturnDate")] 借阅历史 借阅历史)
        {
            if (id != 借阅历史.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(借阅历史);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!借阅历史Exists(借阅历史.ID))
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
            return View(借阅历史);
        }

        // GET: 借阅历史/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 借阅历史 = await _context.借阅历史
                .FirstOrDefaultAsync(m => m.ID == id);
            if (借阅历史 == null)
            {
                return NotFound();
            }

            return View(借阅历史);
        }

        // POST: 借阅历史/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var 借阅历史 = await _context.借阅历史.FindAsync(id);
            _context.借阅历史.Remove(借阅历史);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool 借阅历史Exists(int id)
        {
            return _context.借阅历史.Any(e => e.ID == id);
        }
    }
}

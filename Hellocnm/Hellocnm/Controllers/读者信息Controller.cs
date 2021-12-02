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
    public class 读者信息Controller : Controller
    {
        private readonly HellocnmContext _context;

        public 读者信息Controller(HellocnmContext context)
        {
            _context = context;
        }

        // GET: 读者信息
        public async Task<IActionResult> Index(string searchString)
        {
            var result = await _context.读者信息.ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(v => v.Name.Contains(searchString)).ToList();
            }
           
            return View(result);
        }

        // GET: 读者信息/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 读者信息 = await _context.读者信息
                .FirstOrDefaultAsync(m => m.p_id == id);
            if (读者信息 == null)
            {
                return NotFound();
            }

            return View(读者信息);
        }

        // GET: 读者信息/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: 读者信息/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("p_id,Kind,Name,Sex,Phone,Email,Borrownumber,College,Address,Remark")] readerinformation 读者信息)
        {
            if (ModelState.IsValid)
            {
                _context.Add(读者信息);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(读者信息);
        }

        // GET: 读者信息/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 读者信息 = await _context.读者信息.FindAsync(id);
            if (读者信息 == null)
            {
                return NotFound();
            }
            return View(读者信息);
        }

        // POST: 读者信息/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("p_id,Kind,Name,Sex,Phone,Email,Borrownumber,College,Address,Remark")] readerinformation 读者信息)
        {
            if (id != 读者信息.p_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(读者信息);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!读者信息Exists(读者信息.p_id))
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
            return View(读者信息);
        }

        // GET: 读者信息/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 读者信息 = await _context.读者信息
                .FirstOrDefaultAsync(m => m.p_id == id);
            if (读者信息 == null)
            {
                return NotFound();
            }

            return View(读者信息);
        }

        // POST: 读者信息/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var 读者信息 = await _context.读者信息.FindAsync(id);
            _context.读者信息.Remove(读者信息);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool 读者信息Exists(int id)
        {
            return _context.读者信息.Any(e => e.p_id == id);
        }
    }
}

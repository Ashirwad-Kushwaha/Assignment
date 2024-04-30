using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class todolistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public todolistsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: todolists
        public async Task<IActionResult> Index()
        {
            return View(await _context.todolists.ToListAsync());
        }

        // GET: todolists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolist = await _context.todolists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolist == null)
            {
                return NotFound();
            }

            return View(todolist);
        }

        // GET: todolists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: todolists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Task,Description,IsCompleted")] todolist todolist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todolist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todolist);
        }

        // GET: todolists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolist = await _context.todolists.FindAsync(id);
            if (todolist == null)
            {
                return NotFound();
            }
            return View(todolist);
        }

        // POST: todolists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Task,Description,IsCompleted")] todolist todolist)
        {
            if (id != todolist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todolist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!todolistExists(todolist.Id))
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
            return View(todolist);
        }

        // GET: todolists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolist = await _context.todolists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolist == null)
            {
                return NotFound();
            }

            return View(todolist);
        }

        // POST: todolists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todolist = await _context.todolists.FindAsync(id);
            if (todolist != null)
            {
                _context.todolists.Remove(todolist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool todolistExists(int id)
        {
            return _context.todolists.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDiary.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MyDiary.Controllers
{
    public class ContentsController : Controller
    {
        private readonly MyDiaryContext _context;

        public ContentsController(MyDiaryContext context)
        {
            _context = context;
        }

        // GET: Contents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Content.ToListAsync());
        }

        // GET: Contents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Content
                .FirstOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // GET: Contents/Create
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");
            return View();
        }

        // POST: Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentId,Title,Text,Created,Writer")] Content content)
        {
            if (ModelState.IsValid)
            {
               // content.Writer = User.Identity.Name;
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(content);
        }

        // GET: Contents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");

            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContentId,Title,Text,Created,Writer")] Content content)
        {
            if (id != content.ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.ContentId))
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
            return View(content);
        }

        // GET: Contents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Content.FirstOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var content = await _context.Content.FindAsync(id);
            _context.Content.Remove(content);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentExists(int id)
        {
            return _context.Content.Any(e => e.ContentId == id);
        }

       //calendar
        public ActionResult CalendarView()
        {
            var list = _context.Content.ToList();
            ViewBag.list = new SelectList(list, "ContentId", "Title");
            return View();
        }
    }
}

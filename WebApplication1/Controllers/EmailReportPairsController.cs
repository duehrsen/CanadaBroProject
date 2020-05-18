using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmailReportPairsController : Controller
    {
        private readonly EmailReportPairContext _context;

        public EmailReportPairsController(EmailReportPairContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all report pairs
        /// </summary>
        /// <returns></returns>
        // GET: EmailReportPairs
/*        public async Task<IActionResult> Index()
        {
            return View(await _context.Pairs.ToListAsync());
        }*/
        
        public async Task<IActionResult> Index(string id)
        {
            var pairs = from p in _context.Pairs
                        select p;

            if (!String.IsNullOrEmpty(id))
            {
                pairs = pairs.Where(e => e.Email.Contains(id));
            }
            //var constEmail = "chris@duehrsen.ca";


            return View(await pairs.ToListAsync());

        
        }

        /// <summary>
        /// Get pairs by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>the id</returns>
        // GET: EmailReportPairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailReportPair = await _context.Pairs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emailReportPair == null)
            {
                return NotFound();
            }

            return View(emailReportPair);
        }

        /// <summary>
        /// Create a new report pair
        /// </summary>
        /// <returns>Success</returns>
        // GET: EmailReportPairs/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create a new report pair
        /// </summary>
        /// <param name="emailReportPair"></param>
        /// <returns></returns>
        // POST: EmailReportPairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,ReportName")] EmailReportPair emailReportPair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailReportPair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailReportPair);
        }

        /// <summary>
        /// Find an existing pair by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>one report pair</returns>
        // GET: EmailReportPairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailReportPair = await _context.Pairs.FindAsync(id);
            if (emailReportPair == null)
            {
                return NotFound();
            }
            return View(emailReportPair);
        }

        /// <summary>
        /// Edit pair
        /// </summary>
        /// <param name="id"></param>
        /// <param name="emailReportPair"></param>
        /// <returns></returns>
        // POST: EmailReportPairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,ReportName")] EmailReportPair emailReportPair)
        {
            if (id != emailReportPair.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailReportPair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailReportPairExists(emailReportPair.ID))
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
            return View(emailReportPair);
        }

        /// <summary>
        /// Delete pair
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: EmailReportPairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailReportPair = await _context.Pairs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emailReportPair == null)
            {
                return NotFound();
            }

            return View(emailReportPair);
        }

        /// <summary>
        /// Delete pair by post verb
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: EmailReportPairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emailReportPair = await _context.Pairs.FindAsync(id);
            _context.Pairs.Remove(emailReportPair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if pair exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool EmailReportPairExists(int id)
        {
            return _context.Pairs.Any(e => e.ID == id);
        }
    }
}

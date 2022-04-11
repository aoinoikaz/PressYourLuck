using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PressYourLuck.Data;
using PressYourLuck.Helpers;
using PressYourLuck.Models;

namespace PressYourLuck.Controllers
{
    public class AuditController : Controller
    {
        private static AuditContext _context;

        // Because i have the stataic add audit method, we must set the context manually
        // because this controller should be used at all times, not just when a user wants to see the view.
        // Therefore, if this context was being set in the constructor when a user clicks on audit link in nav bar,
        // it will end up being null. We must set custom options in the context which can be seen in startup.cs
        public static void SetContext(AuditContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This function manually adds an audit to the database. 
        /// </summary>
        /// <param name="audit">A manually created model that will be used to save the data</param>
        public static void AddAudit(Audit audit)
        {
            _context.Add(audit);
            _context.SaveChanges();
        }

        /// <summary>
        /// Displays the audit view and will load the data 
        /// </summary>
        /// <returns> An updated audit view</returns>
        public async Task<IActionResult> Index(string filter)
        {
            // If no coins have been set then default it to 0
            if (!HttpContext.Request.Cookies.ContainsKey("coins"))
            {
                ViewData["coins"] = 0.ToString("N2");
            }
            else
            {
                // Simply get the data to display
                Utility.GetPlayer(HttpContext);
                ViewData["username"] = PlayerController.CurrentPlayer.Username;
                ViewData["coins"] = PlayerController.CurrentPlayer.Coins.ToString("N2");
            }

            // Return the view depending on which filter
            if (!string.IsNullOrEmpty(filter))
            {
                ViewBag.Filter = filter;
                Utility.SetSessionVariable(HttpContext, "filter", filter);

                switch (filter)
                {
                    case "cashIn":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Cash In").OrderByDescending(a => a.DateCreated).ToList());
                    case "cashOut":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Cash Out").OrderByDescending(a => a.DateCreated).ToList());
                    case "win":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Win").OrderByDescending(a => a.DateCreated).ToList());
                    case "lose":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Lose").OrderByDescending(a => a.DateCreated).ToList());
                    case "all":
                        return View(_context.Audit.Include(a => a.AuditType).OrderByDescending(a => a.DateCreated).ToList());
                }
            }
            else
            {
                // no filter set, retrieve from session
                string savedFilter = (string)Utility.GetSessionVariable(HttpContext, "filter");
                ViewBag.Filter = savedFilter;

                switch (savedFilter)
                {
                    case "cashIn":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Cash In").OrderByDescending(a => a.DateCreated).ToList());
                    case "cashOut":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Cash Out").OrderByDescending(a => a.DateCreated).ToList());
                    case "win":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Win").OrderByDescending(a => a.DateCreated).ToList());
                    case "lose":
                        return View(_context.Audit.Include(a => a.AuditType).Where(a => a.AuditType.Name == "Lose").OrderByDescending(a => a.DateCreated).ToList());
                    case "all":
                        return View(_context.Audit.Include(a => a.AuditType).OrderByDescending(a => a.DateCreated).ToList());
                }
            }

            // No filter return all
            return View(await _context.Audit.Include(a => a.AuditType).OrderByDescending(a => a.DateCreated).ToListAsync());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Helpers;
using PressYourLuck.Models;

namespace PressYourLuck.Controllers
{
    public class PlayerController : Controller
    {
        public static Player CurrentPlayer { get; set; }
    
        /// <summary>
        /// Simply displays the data
        /// </summary>
        /// <returns> Updated view for player controller </returns>
        public IActionResult Index()
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
                ViewData["username"] = CurrentPlayer.Username;
                ViewData["coins"] = CurrentPlayer.Coins.ToString("N2");
            }

            // If the player has cashed out, then display an alert, and reset the player
            if (CurrentPlayer.CashedOut)
            {
                if (CurrentPlayer.Coins > 0)
                { 
                    TempData["Message"] = "<span class='alert alert-info'>You cashed out for " + CurrentPlayer.Coins.ToString("N2") + " coins!</span>";
                }
                CurrentPlayer.Reset();
            }

            return View();
        }


        // Invoked when the user presses on the join game button in the web browser.
        // This will set the username and coins in the cookies.
        /// <summary>
        /// Called when the user presses on the join game button in the web browser. 
        /// It will setup the player's information and save it accordingly.
        /// </summary>
        /// <param name="player"> Typed model that contains our data from the create form.</param>
        /// <returns> A view with the updated player data</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Username, Coins")] Player player)
        {
            if (ModelState.IsValid)
            {
                Utility.SavePlayer(HttpContext, player);

                if (!CurrentPlayer.CashedIn)
                { 
                    CurrentPlayer.CashedIn = true;

                    Audit audit = new();
                    audit.Amount = CurrentPlayer.Coins;
                    audit.PlayerName = CurrentPlayer.Username;
                    audit.AuditTypeId = 1;

                    AuditController.AddAudit(audit);
                }
                return RedirectToAction("Index", "Home", CurrentPlayer);
            }
            ViewData["coins"] = 0.ToString("N2");
            return View(player);
        }


        /// <summary>
        /// This method simply cashes out the player and cleans up after it
        /// </summary>
        /// <returns> A redirect to the home page for a new user to play</returns>
        public IActionResult Cashout()
        {
            if (!CurrentPlayer.CashedOut)
            {
                CurrentPlayer.CashedOut = true;

                Audit audit = new();
                audit.PlayerName = CurrentPlayer.Username;
                audit.Amount = CurrentPlayer.Coins;
                audit.AuditTypeId = 2;

                AuditController.AddAudit(audit);
            }

            Utility.DeleteCookie(HttpContext, "username");
            Utility.DeleteCookie(HttpContext, "coins");
            HttpContext.Session.Remove("game_tileList");

            return RedirectToAction("Index", "Home");
        }
    }
}

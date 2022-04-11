using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System.Diagnostics;


namespace PressYourLuck.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            if (PlayerController.CurrentPlayer == null)
            {
                PlayerController.CurrentPlayer = new Player();
            }
        }

        /// <summary>
        ///  Simply displays the data
        /// </summary>
        /// <param name="player"> Updated view for home controller</param>
        /// <returns> Updated view for home controller </returns>
        public IActionResult Index()
        {
            // If there is no username set, redirect to new player login page
            if (!HttpContext.Request.Cookies.ContainsKey("username"))
            {
                return RedirectToAction("Index", "Player");
            }
            else
            {
                Utility.GetPlayer(HttpContext);
                ViewData["username"] = PlayerController.CurrentPlayer.Username;
                ViewData["coins"] = PlayerController.CurrentPlayer.Coins.ToString("N2");

                if (PlayerController.CurrentPlayer.CoinsTaken)
                {
                    TempData["Message"] = "<span class='alert alert-info'>BIG WINNER! You cashed out for " + PlayerController.CurrentPlayer.CurrentBet.ToString("N2") + " coins! Care to press your luck again?</span>";
                    PlayerController.CurrentPlayer.CoinsTaken = false;
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
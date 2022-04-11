using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PressYourLuck.Helpers;
using System.Collections.Generic;

using PressYourLuck.Models;

namespace PressYourLuck.Controllers
{
    public class GameController : Controller
    {
        public static List<Tile> Tiles { get; set; }

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method is called when the take coin button is clicked
        /// </summary>
        /// <returns> A redirect to the home page </returns>
        public IActionResult TakeCoins()
        {
            Audit audit = new();
            audit.Amount = PlayerController.CurrentPlayer.CurrentBet;
            audit.PlayerName = PlayerController.CurrentPlayer.Username;
            audit.AuditTypeId = 3;
            AuditController.AddAudit(audit);

            PlayerController.CurrentPlayer.Coins += PlayerController.CurrentPlayer.CurrentBet;
            PlayerController.CurrentPlayer.CoinsTaken = true;
            Utility.SavePlayer(HttpContext, PlayerController.CurrentPlayer);

            HttpContext.Session.Remove("game_tileList");

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// This method handles changing tile visibility, and calculating bets/totals
        /// </summary>
        /// <param name="tile"> The underlying tile in the tile list</param>
        /// <returns> The game view with updated tile list</returns>
        public IActionResult FlipTile(Tile tile)
        {
            // We must do this to update the underlying list
            foreach (Tile t in Tiles)
            {
                if (t.TileIndex == tile.TileIndex)
                {
                    t.Visible = true;
                }
            }

            // Player lost, reset bet, reveal tiles and continue
            if (double.Parse(tile.Value) == 0.0)
            {
                Audit audit = new();
                audit.Amount = PlayerController.CurrentPlayer.OriginalBet;
                audit.PlayerName = PlayerController.CurrentPlayer.Username;
                audit.AuditTypeId = 4;
                AuditController.AddAudit(audit);

                PlayerController.CurrentPlayer.CurrentBet = 0;
                Utility.SavePlayer(HttpContext, PlayerController.CurrentPlayer);

                TempData["Message"] = "<span class='alert alert-info'>Oh no! You busted out. Better luck next time!</span>";

                foreach (Tile t in Tiles)
                {
                    t.Visible = true;
                }
            }
            // Player won a round
            else
            {
                PlayerController.CurrentPlayer.CurrentBet *= double.Parse(tile.Value);
                Utility.SavePlayer(HttpContext, PlayerController.CurrentPlayer);

                TempData["Message"] = "<span class='alert alert-info'>Congrats you've found a " + tile.Value + " multiplier! All remaining values have doubled. Will you Press Your Luck?</span>";

                // Double each unopened tile 
                foreach (Tile t in Tiles)
                {
                    if (!t.Visible)
                    {
                        double newAmount = double.Parse(t.Value) * 2;
                        t.Value = newAmount.ToString("N2");
                    }
                }
            }

            if (PlayerController.CurrentPlayer.Coins <= 0)
            {
                TempData["Message"] = "<span class='alert alert-info'>You've lost all your coins and must enter more to keep playing!</span>";
            }

            ViewData["coins"] = PlayerController.CurrentPlayer.Coins.ToString("N2");
            ViewData["currentBet"] = PlayerController.CurrentPlayer.CurrentBet.ToString("N2");

            return View("Index", Tiles);
        }
        
        /// <summary>
        /// This is called automatically when the user inputs a wage/bet. IT will generate the game 
        /// </summary>
        /// <param name="currentBet"></param>
        /// <returns></returns>
        public IActionResult Index(double originalBet)
        {

            // If our game hasnt been generated, then generate it, serialize it and store it in the session
            if (string.IsNullOrEmpty((string)Utility.GetSessionVariable(HttpContext, "game_tileList")))
            {
                _logger.LogInformation("Index: generating and serializing");
                Tiles = Utility.GenerateGameAndSerialize(HttpContext);
            }
            // Otherwise, retrieve the serialized game from the session, deserialize it to a list, and pass it back
            else
            {
                _logger.LogInformation("Index: deserializing");

                Tiles = Utility.DeserializeGame(HttpContext);
            }

            // Handle the deduction, then propogate changes
            PlayerController.CurrentPlayer.OriginalBet = originalBet;
            PlayerController.CurrentPlayer.CurrentBet = originalBet;
            PlayerController.CurrentPlayer.Coins -= originalBet;
            Utility.SavePlayer(HttpContext, PlayerController.CurrentPlayer);

            ViewData["coins"] = PlayerController.CurrentPlayer.Coins.ToString("N2");
            ViewData["currentBet"] = PlayerController.CurrentPlayer.CurrentBet.ToString("N2");
           
            return View(Tiles);
        }
    }
}

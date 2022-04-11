using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PressYourLuck.Controllers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;

namespace PressYourLuck.Helpers
{
    /// <summary>
    /// Utility class I wrote that provides helper functions to the system.
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Get session variable based on key
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        /// <param name="key">The session variable key</param>
        /// <returns></returns>
        public static object GetSessionVariable(HttpContext httpContext, string key)
        {
            return httpContext.Session.GetString(key);
        }

        /// <summary>
        /// Set session variable based on key value
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        /// <param name="key">The session variable key </param>
        /// <param name="value">The value to be set</param>
        public static void SetSessionVariable(HttpContext httpContext, string key, string value)
        {
            httpContext.Session.SetString(key, value);
        }

        /// <summary>
        /// Delete a cookie if it exists
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key">Key of the cookie</param>
        public static void DeleteCookie(HttpContext httpContext, string key)
        {
            if (httpContext.Request.Cookies.Keys.Contains(key))
            {
                // Set the cookie as expired which 'deletes' them
                httpContext.Response.Cookies.Delete(key);
            }
        }

        /// <summary>
        /// Saves a cookie based on key value
        /// </summary>
        /// <param name="httpContext">The current httpcontext</param>
        /// <param name="key">Key of the cookie</param>
        /// <param name="value">Value to be set in the cookie</param>
        private static void SaveCookie(HttpContext httpContext, string key, string value)
        {
            httpContext.Response.Cookies.Append(key, value);
        }

        /// <summary>
        /// Return a cookie which caller has to unbox
        /// </summary>
        /// <param name="httpContext">The current httpcontext</param>
        /// <param name="key">Key of the cookie</param>
        /// <returns>The unboxed cookie</returns>
        private static object GetCookie(HttpContext httpContext, string key)
        {
            return httpContext.Request.Cookies[key];
        }

        /// <summary>
        /// This method saves the data to the cookies
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        /// <param name="player">The player object to save to</param>
        public static void SavePlayer(HttpContext httpContext, Player player)
        {
            SaveCookie(httpContext, "username", player.Username);
            SaveCookie(httpContext, "coins", player.Coins.ToString());
            SetSessionVariable(httpContext, "currentBet", player.CurrentBet.ToString());
            PlayerController.CurrentPlayer.Username = player.Username;
            PlayerController.CurrentPlayer.Coins = player.Coins;
            PlayerController.CurrentPlayer.CurrentBet = player.CurrentBet;
        }

        /// <summary>
        /// This method upades the underlying data structure with the cookie data
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        public static void GetPlayer(HttpContext httpContext)
        {
            PlayerController.CurrentPlayer.Username = (string)GetCookie(httpContext, "username");
            PlayerController.CurrentPlayer.Coins = double.Parse((string)GetCookie(httpContext, "coins"));
            //PlayerController.CurrentPlayer.CurrentBet = 
        }

        /// <summary>
        /// Deserialize the tile list which was stored in the session
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        /// <returns>Returns a deserialized tile list</returns>
        public static List<Tile> DeserializeGame(HttpContext httpContext)
        {
            string tileList = (string)GetSessionVariable(httpContext, "game_tileList");
            List<Tile> deserializedTileList = JsonConvert.DeserializeObject<List<Tile>>(tileList);
            return deserializedTileList;
        }

        /// <summary>
        /// Serialize the tile list and store it in the session
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>Returns the tile list which is generated on new game</returns>
        public static List<Tile> GenerateGameAndSerialize(HttpContext httpContext)
        {
            List<Tile> tileList = GenerateNewGame();
            string serializedTileList = JsonConvert.SerializeObject(tileList);
            SetSessionVariable(httpContext, "game_tileList", serializedTileList);

            return tileList;
        }

        public static List<Tile> GenerateNewGame()
        {
            var tileList = new List<Tile>();
            Random r = new();
            for (int i = 0; i < 12; i++)
            {
                double randomValue = 0;
                if (r.Next(1, 4) != 1)
                {
                    randomValue = (r.NextDouble() + 0.5) * 2;
                }

                var tile = new Tile()
                {
                    TileIndex = i,
                    Visible = false,
                    Value = randomValue.ToString("N2")
                };

                tileList.Add(tile);
            }
            return tileList;
        }
    }
}
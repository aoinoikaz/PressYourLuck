using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    /// <summary>
    /// This player class is the underlying data structure that holds and keeps our players data updated
    /// in the game. Keeps track of username, coins, and current bet.
    /// </summary>
    public class Player
    {
        private string username;
        private double coins;
        private double currentBet;
        private double originalBet;

        public double Profit { get; set; }
        public bool CoinsTaken { get; set; }
        public bool CashedOut { get; set; }
        public bool CashedIn { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "Username cannot be greater than 30 characters!")]
        public string Username 
        {
            get 
            {  
                return username; 
            }
            set
            {
                username = value;
            }
        }

        [Required]
        [Range(1, 10000, ErrorMessage = "Must choose between 1 and 10,000 coins!")]
        public double Coins 
        {
            get 
            {
                return coins;
            }
            set
            {
                coins = value;
            }
        }

        public double OriginalBet
        {
            get
            {
                return originalBet;
            }
            set
            {
                originalBet = value;
            }
        }

        public double CurrentBet
        {
            get
            {
                return currentBet;
            }
            set
            {
                currentBet = value;
            }
        }

        /// <summary>
        /// This method simply resets the players information to be re used 
        /// </summary>
        public void Reset()
        {
            Profit = 0;
            CoinsTaken = false;
            CashedOut = false;
            Username = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PlayerManagerMVC;



namespace PlayerManagerMV
{

    public class Controller
    {
        /// The list of all players
        private readonly PlayersList playerList;

        // Comparer for comparing player by name (alphabetical order)
        private readonly IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private readonly IComparer<Player> compareByNameReverse;


        private IView view;



        public Controller(
            PlayersList playerList,
            IComparer<Player> compareByName,
            IComparer<Player> compareByNameReverse)
        {


            this.playerList = playerList;
            this.compareByName = compareByName;
            this.compareByNameReverse = compareByNameReverse;

        }

        

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        public void Run(IView view)
        {
            this.view = view;
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                option = view.MainMenu();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        // Insert player
                        InsertPlayer();
                        break;
                    case "2":
                        view.ShowPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.ShowGoodbyeMessage();
                        break;
                    default:
                        view.ShowInvalidOptionMessage();
                        break;
                }

                // Wait for user to press a key...
                view.WaitForUser();

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
    

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Player newPlayer = view.AskForPlayerInfo();
            playerList.Add(newPlayer);
        }

    

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            
            // Enumerable of players with score higher than the minimum score
            IEnumerable<Player> playersWithScoreGreaterThan;

            // Minimum score user should have in order to be shown
            int minScore = view.AskForMinScore();

            // Get players with score higher than the user-specified value
            playersWithScoreGreaterThan =
                playerList.GetPlayersWithScoreGreaterThan(minScore);

            // List all players with score higher than the user-specified value
            view.ShowPlayers(playersWithScoreGreaterThan);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
       
        /// <summary>
        ///  Sort player list by the order specified by the user.
        /// </summary>
        private void SortPlayerList()
        {
            PlayerOrder playerOrder = view.AskForPlayerOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
                default:
                    view.ShowInvalidOptionMessage();
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace PlayerManagerMVC2
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Controller
    {
        /// The list of all players
        private readonly List<Player> playerList;

        // Comparer for comparing player by name (alphabetical order)
        private readonly IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private readonly IComparer<Player> compareByNameReverse;

        private IView view;


        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>


        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        public Controller(IView view, string path)
        {
            // Initialize player comparers
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
            this.view = view;

            string[] nameList = File.ReadAllLines(path);

            playerList = new List<Player>();

            foreach (string player in nameList)
            {
                string[] playerDivided = player.Split(",");

                playerList.Add
                (new Player(playerDivided[0].Trim(), Convert.ToInt32(playerDivided[1].Trim())));
            }
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        public void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                option = view.DisplayMenu();


                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        // Insert player
                        view.AddNewPlayer(playerList);
                        break;
                    case "2":
                        view.ListOfAllPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.LastProgramMessage();
                        break;
                    default:
                        view.ErrorMessage();
                        break;
                }
                view.WaitForInput();

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }


        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            // Enumerable of players with score higher than the minimum score
            IEnumerable<Player> playersWithScoreGreaterThan;

            // Get players with score higher than the user-specified value
            playersWithScoreGreaterThan =
                GetPlayersWithScoreGreaterThan(view.AskUserForAMinScore());

            // List all players with score higher than the user-specified value
            view.ListOfAllPlayers(playersWithScoreGreaterThan);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            // Cycle all players in the original player list
            foreach (Player p in playerList)
            {
                // If the current player has a score higher than the
                // given value....
                if (p.Score > minScore)
                {
                    // ...return him as a member of the player enumerable
                    yield return p;
                }
            }
        }

        /// <summary>
        ///  Sort player list by the order specified by the user.
        /// </summary>
        private void SortPlayerList()
        {

            switch (view.UserInputForOrder())
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
                    Console.Error.WriteLine("\n>>> Unknown player order! <<<\n");
                    break;
            }
        }
    }
}
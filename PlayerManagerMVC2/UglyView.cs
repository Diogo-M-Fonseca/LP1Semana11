using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC2
{
    public class View : IView
    {
        public void AddNewPlayer(List<Player> playerList)
        {
            // Variables
            string name;
            int score;
            Player newPlayer;

            // Ask for player info
            Console.WriteLine("\nInsert player");
            Console.WriteLine("-------------\n");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Score: ");
            score = Convert.ToInt32(Console.ReadLine());

            // Create new player and add it to list
            newPlayer = new Player(name, score);
            playerList.Add(newPlayer);
        }

        public int AskUserForAMinScore()
        {
            Console.Write("\nMinimum score player should have? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----\n");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. Sort players");
            Console.WriteLine("0. Quit\n");
            Console.Write("Your choice > ");
            return Console.ReadLine();
        }

        public void ErrorMessage()
        {
            Console.Error.WriteLine("\n>>> Unknown option! <<<\n");

        }

        public void LastProgramMessage()
        {
            Console.WriteLine("Bye!");
        }

        public void ListOfAllPlayers(IEnumerable<Player> ListOfPlayers)
        {
            Console.WriteLine("\nList of players");
            Console.WriteLine("-------------\n");

            // Show each player in the enumerable object
            foreach (Player p in ListOfPlayers)
            {
                Console.WriteLine($" -> {p.Name} with a score of {p.Score}");
            }
            Console.WriteLine();
        }

        public PlayerOrder UserInputForOrder()
        {
            Console.WriteLine("Player order");
            Console.WriteLine("------------");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByScore}. Order by score");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByName}. Order by name");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");
            Console.WriteLine("");
            Console.Write("> ");

            return Enum.Parse<PlayerOrder>(Console.ReadLine());
        }

        public void WaitForInput()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }
    }
}
using System;
using System.Collections.Generic;
using PlayerManagerMVC;


namespace PlayerManagerMV
{

    public class UglyView : IView
    {

        public int AskForMinScore()
        {
            // Ask the user what is the minimum score
            Console.Write("\nMinimum score player should have? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public Player AskForPlayerInfo()
        {

            // Variables
            string name;
            int score;

            //Ask for player info
            Console.WriteLine("\nInsert player");
            Console.WriteLine("-------------\n");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Score: ");
            score = Convert.ToInt32(Console.ReadLine());

            // Create new player and add it to list
            return new Player(name, score);
        }


        public PlayerOrder AskForPlayerOrder()
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

        public string MainMenu()
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
        public void ShowGoodbyeMessage()
        {
            Console.WriteLine("Bye");
        }

        public void ShowInvalidOptionMessage()
        {
            Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
        }


        public void ShowPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("\nList of players");
            Console.WriteLine("-------------\n");

            // Show each player in the enumerable object
            foreach (Player p in playersToList)
            {
                Console.WriteLine($" -> {p.Name} with a score of {p.Score}");
            }
            Console.WriteLine();
        }

        public void WaitForUser()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;



namespace PlayerManagerMVC2
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main(string[] args)
        {
            //Inicialize player comparers
            // Initialize player comparers
            IComparer<Player> compareByName = new CompareByName(true);
            IComparer<Player> compareByNameReverse = new CompareByName(false);
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Erro: Nome do ficheiro com jogadores não fornecido.");
                Console.Error.WriteLine("Uso: PlayerManagerMVC <ficheiro>");
                return;
            }

            string filePath = args[0];

            var controller = new Controller(filePath);
            controller.Run();

        }
    }
}
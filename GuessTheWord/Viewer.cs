using System;
using System.Collections.Generic;
namespace GuessTheWord
{
    public class Viewer : IView
    {
        public void GuessTheWord(string chosenWord, string guess)
        {
            do
            {
                Console.Write("Your guess: ");
                guess = Console.ReadLine().Trim().ToLower();

                if (guess != chosenWord)
                    Console.WriteLine("Incorrect. Try again.");
            } while (guess != chosenWord);

            Console.WriteLine("Correct! Well done!");
            Console.WriteLine($"The word was \"{chosenWord}\".");
        }

        public void RevealedLetterPos(string chosenWord, string hint)
        {
            // Determine revealed letter positions (up to 50% of the length)
            int length = chosenWord.Length;
            int numToReveal = Math.Max(1, (int)Math.Floor(length * 0.4));  // at least 1 letter
            char[] display = new string('_', length).ToCharArray();
            //hashseeding here tbd
            Console.WriteLine("Guess the full word!");
            Console.WriteLine($"Hint: It's a {hint}.");
            Console.WriteLine($"Word: {new string(display)}");
        }

        public string SelectRandomWord(IDictionary<string, string> wordsWithHints)
        {
            Random rand = new Random();
            List<string> words = new List<string>(wordsWithHints.Keys);
            string chosenWord = words[rand.Next(words.Count)];
            string hint = wordsWithHints[chosenWord];
            return hint;
        }
    }
}
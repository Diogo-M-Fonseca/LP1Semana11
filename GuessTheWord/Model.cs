using System;
using System.Collections.Generic;

namespace GuessTheWord
{
    public class Model
    {
        public void HashSedding(string chosenWord, int numToReveal,
        int length, char[] display)
        {
            // Use hash code of the word for consistent seeding
            int seed = chosenWord.GetHashCode();
            Random maskRand = new Random(seed);

            HashSet<int> revealedIndices = new HashSet<int>();
            while (revealedIndices.Count < numToReveal)
            {
                int index = maskRand.Next(length);
                revealedIndices.Add(index);
            }

            foreach (int i in revealedIndices)
            {
                display[i] = chosenWord[i];
            }
            
        }
    }
}
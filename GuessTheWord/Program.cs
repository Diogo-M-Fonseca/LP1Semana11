using System;
using System.Collections.Generic;
using System.Threading.Channels;
using GuessTheWord;
namespace GuessTheWord
{
    public class Program
    {
        private static void Main()
        {
            IDictionary<string, string> wordsWithHints = new Dictionary<string, string>()
        {
            { "apple", "fruit" },
            { "banana", "fruit" },
            { "tiger", "animal" },
            { "elephant", "animal" },
            { "guitar", "instrument" },
            { "violin", "instrument" },
            { "canada", "country" },
            { "brazil", "country" },
            { "laptop", "object" },
            { "microscope", "scientific instrument" }
        };
            
        }
    }
}
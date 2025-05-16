using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public interface IView
    {
        string SelectRandomWord(IDictionary<string, string> wordsWithHints);
        void RevealedLetterPos(string chosenWord, string hint);
        void GuessTheWord(string chosenWord, string guess);

    }
}
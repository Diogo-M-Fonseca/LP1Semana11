using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC2
{
    public interface IView
    {
        string DisplayMenu();
        void AddNewPlayer(List<Player> playerList);
        void LastProgramMessage();
        void ListOfAllPlayers(IEnumerable<Player> ListOfPlayers);
        int AskUserForAMinScore();
        void ErrorMessage();
        void WaitForInput();
        PlayerOrder UserInputForOrder();

    }
}
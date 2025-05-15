using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PlayerManagerMVC
{
    public class PlayersList : List<Player>
    {
        public IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            // Cycle all players in the original player list
            foreach (Player p in this)
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

    }
}
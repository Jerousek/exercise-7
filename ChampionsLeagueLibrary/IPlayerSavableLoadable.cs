using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeagueLibrary
{
    public interface IPlayerSavableLoadable
    {
        Player[] Save();
        void Load(Player[] loadedPlayers);
    }
}

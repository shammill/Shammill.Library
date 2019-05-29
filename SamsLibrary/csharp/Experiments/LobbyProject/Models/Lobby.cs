using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Models
{
    public class Lobby
    {
        Guid id;
        string name;
        List<Player> players;

        int maximumSize;
        bool isPublic;
        bool isJoinable;
        bool hasGameInProgress;
        int gameId;

        // useful for filters
        RegionEnum region;
        string gameMode;
    }
}

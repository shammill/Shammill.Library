using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Models
{
    public class UpdateLobbyRequest
    {
        public string name;

        public int maximumSize;
        public bool isPublic;
        public bool isJoinable;
        public bool hasGameInProgress;

        // useful for filters
        public RegionEnum region;
        public string gameMode;
    }
}

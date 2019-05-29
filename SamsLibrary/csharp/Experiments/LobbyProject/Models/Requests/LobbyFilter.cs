using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Models
{
    public class LobbyFilter
    {
        public bool isPublic;
        public bool hasGameInProgress;

        // useful for filters
        public RegionEnum region;
        public string gameMode;
    }
}

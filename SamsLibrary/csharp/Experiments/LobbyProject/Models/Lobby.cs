﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Models
{
    public class Lobby
    {
        public Guid id;
        public string name;
        public List<Player> players;

        public int maximumSize;
        public bool isPublic;
        public bool isJoinable;
        public bool hasGameInProgress;
        public int gameId;

        // useful for filters
        public RegionEnum region;
        public string gameMode;
    }
}
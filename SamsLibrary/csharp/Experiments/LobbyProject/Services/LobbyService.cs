using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsLibrary.csharp.Experiments.LobbyProject.Models;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Services
{
    public class LobbyService: ILobbyService
    {
        public LobbyService()
        {
            // HA'd Lobby List Reference
        }

        public Models.Lobby CreateLobby(CreateLobbyRequest createLobbyRequest)
        {
            //maybe use automapper
            Lobby lobby = new Lobby()
            {
                id = new Guid(),
                name = createLobbyRequest.name,
                isPublic = createLobbyRequest.isPublic,
                region = createLobbyRequest.region,
                maximumSize = createLobbyRequest.maximumSize,
                gameMode = createLobbyRequest.gameMode,
                isJoinable = createLobbyRequest.isJoinable,
                players = new List<Player>()
            };
            // Add lead player
        }

        public void DestroyLobby(Guid lobby) {

        }

        Models.Lobby UpdateLobbyDetails(Lobby lobby) { }

        // player based
        bool AddPlayerToLobby(Guid lobby, Player playerId) { }
        bool RemovePlayerFromLobby(Guid lobby, Player playerId) { }
        bool ChangeLobbyLeader(Guid lobby, Player playerId) { }

        // searching/getting
        List<Lobby> GetLobbies(LobbyFilter lobbyFilter) { }
    }
}

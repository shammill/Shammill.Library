using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsLibrary.csharp.Experiments.LobbyProject.Models;
using SamsLibrary.csharp.Experiments.LobbyProject.Services.Interfaces;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Services
{
    public class LobbyService: ILobbyService
    {
        Dictionary<Guid, Lobby> lobbies = new Dictionary<Guid, Lobby>();

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
            lobbies.Add(lobby.id, lobby);

            return lobby;
        }

        public void DestroyLobby(Guid lobbyId) {
            lobbies.Remove(lobbyId);
        }

        public Models.Lobby UpdateLobbyDetails(Lobby lobby) {
            lobbies[lobby.id] = lobby;
            return lobby;
        }

        // player based
        public bool AddPlayerToLobby(Guid lobbyId, Player player) {
            lobbies[lobbyId].players.Add(player);
            return true;
        }

        public bool RemovePlayerFromLobby(Guid lobbyId, Player player) {
            lobbies[lobbyId].players.Remove(player);
            return true;
        }

        public bool ChangeLobbyLeader(Guid lobbyId, Player playerLeader) {
            var isSuccessful = false;
            foreach (var player in lobbies[lobbyId].players)
            {
                if (player.id == playerLeader.id)
                {
                    player.isLobbyLeader = true;
                    isSuccessful = true;
                }
                else
                {
                    player.isLobbyLeader = false;
                }
            }
            return isSuccessful;
        }

        // searching/getting
        public List<Lobby> GetLobbies(LobbyFilter lobbyFilter) {
            List<Lobby> filteredLobbies = lobbies.Where(lobby => lobby.Value.region == lobbyFilter.region)
                    .Where(lobby => lobby.Value.isPublic == true)
                    .Where(lobby => lobby.Value.hasGameInProgress == lobbyFilter.hasGameInProgress)
                    .Select(x => x.Value)
                    .ToList();

            return filteredLobbies;
        }
    }
}

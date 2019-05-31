using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsLibrary.csharp.Experiments.LobbyProject.Models;

namespace SamsLibrary.csharp.Experiments.LobbyProject.Services.Interfaces
{
    public interface ILobbyService
    {
        Models.Lobby CreateLobby(CreateLobbyRequest lobbyRequest);
        void DestroyLobby(Guid lobby);

        Models.Lobby UpdateLobbyDetails(Lobby lobby);

        bool AddPlayerToLobby(Guid lobby, Player playerId);
        bool RemovePlayerFromLobby(Guid lobby, Player playerId);
        bool ChangeLobbyLeader(Guid lobby, Player playerId);

        List<Lobby> GetLobbies(LobbyFilter lobbyFilter);
    }
}

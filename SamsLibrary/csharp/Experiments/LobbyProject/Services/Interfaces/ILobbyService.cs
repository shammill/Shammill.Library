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
        Models.Lobby CreateLobby();
        void DestroyLobby(Guid lobby);

        bool AddPlayerToLobby(Guid lobby, Player playerId);
        bool RemovePlayerFromLobby(Guid lobby, Player playerId);


    }
}

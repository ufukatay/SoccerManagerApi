using Entitites.Dtos.Player;
using Entitites.Dtos.Team;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Mappers
{
    public static class PlayerMappers
    {
        public static PlayerDto ToPlayerDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                TeamId = player.TeamId,
                firstName = player.firstName,
                lastName = player.lastName,
                country = player.country,
                age = player.age,
                marketValue = player.marketValue,
                position = player.position,
                isInTranferList = player.isInTranferList,
                askedPrice = player.askedPrice,
            };
        }

        public static Player ToPlayerFromUpdate (this UpdatePlayerDto player)
        {
            return new Player
            {
                country = player.country,
                firstName = player.firstName,
                lastName = player.lastName,
            };
        }

        public static Player ToPlayerFromUpdateTransferList (this TransferListPlayerDto player)
        {
            return new Player
            {
                isInTranferList = player.isIntransferList,
                askedPrice = player.askedPrice,
            };
        }
    }
}

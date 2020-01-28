using Demo.PersistenceLayer.Models;
using NadzFxstreet.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Repositories.Interfaces
{
    public interface ISqlPlayerRepository
    {
        Player GetPlayerById(int Id);
        PlayerDto GetPlayerDtoById(int Id);
        List<PlayerDto> GetAllPlayers();
        Player Add(Player Player);
        Player Update(Player PlayerChanges);
        Player Delete(int Id);

        List<StatisticsDto> GetRedCards();
        List<StatisticsDto> GetYellowCards();
        List<MinutesDto> GetMinutes();
    }


}

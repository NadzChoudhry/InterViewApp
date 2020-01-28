using Demo.PersistenceLayer;
using Demo.PersistenceLayer.Models;
using NadzFxstreet.Entities.Dtos;
using NadzFxstreet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NadzFxstreet.Repositories.Implementation
{
    public class SqlPlayerRepository : ISqlPlayerRepository
    {
        private readonly FxStreetDemoCtx context;

        public SqlPlayerRepository(FxStreetDemoCtx context)
        {
            this.context = context;
        }

        public Player Add(Player Player)
        {
            context.Players.Add(Player);
            context.SaveChanges();
            return Player;
        }

        public Player Delete(int Id)
        {
            Player Player = context.Players.Find(Id);
            if (Player != null)
            {
                context.Players.Remove(Player);
                context.SaveChanges();
            }
            return Player;
        }


        public List<PlayerDto> GetAllPlayers()
        {
            return this.context.Players.Select(p => new PlayerDto()
            {
                name = p.Name,
                minutesPlayed = p.MinutesPlayed,
                number = p.Number,
                redCards = p.RedCards,
                teamName = p.TeamName,
                yellowCards = p.YellowCards
            }).ToList();
        }


        public Player GetPlayer(int Id)
        {
            return context.Players.Find(Id);
        }

        public Player GetPlayerById(int Id)
        {
            return context.Players.Find(Id);
        }

        public PlayerDto GetPlayerDtoById(int Id)
        {
            return context.Players
                .Where(p => p.Id == Id)
                .Select(p => new PlayerDto()
                {
                    name = p.Name,
                    minutesPlayed = p.MinutesPlayed,
                    number = p.Number,
                    redCards = p.RedCards,
                    teamName = p.TeamName,
                    yellowCards = p.YellowCards
                }).FirstOrDefault();
        }
        public Player Update(Player PlayerChanges)
        {
            var Player = context.Players.Attach(PlayerChanges);
            Player.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return PlayerChanges;
        }
        public List<StatisticsDto> GetRedCards()
        {
            var res = context.Players
                        .Where(a => a.RedCards > 0)
                        .ToList().GroupBy(a => a.Id)
                       .Select(a => new StatisticsDto()
                       {
                           id = a.Key,
                           total = a.Sum(b => b.RedCards),
                           name = a.Where(b => b.Id == a.Key).Select(b => b.Name).FirstOrDefault(),
                           teamName = a.Where(b => b.Id == a.Key).Select(b => b.TeamName).FirstOrDefault()
                       }).ToList();

            var res2 = context.Managers
                        .Where(a => a.RedCards > 0)
                        .ToList().GroupBy(a => a.Id)
                       .Select(a => new StatisticsDto()
                       {
                           id = a.Key,
                           total = a.Sum(b => b.RedCards),
                           name = a.Where(b => b.Id == a.Key).Select(b => b.Name).FirstOrDefault(),
                           teamName = a.Where(b => b.Id == a.Key).Select(b => b.TeamName).FirstOrDefault()
                       }).ToList();
            res.AddRange(res2);

            return res;
        }

        public List<StatisticsDto> GetYellowCards()
        {
            var res = context.Players
                        .Where(a => a.YellowCards > 0)
                        .ToList().GroupBy(a => a.Id)
                       .Select(a => new StatisticsDto()
                       {
                           id = a.Key,
                           total = a.Sum(b => b.YellowCards),
                           name = a.Where(b => b.Id == a.Key).Select(b => b.Name).FirstOrDefault(),
                           teamName = a.Where(b => b.Id == a.Key).Select(b => b.TeamName).FirstOrDefault()
                       }).ToList();

            var res2 = context.Managers
                        .Where(a => a.YellowCards > 0)
                        .ToList().GroupBy(a => a.Id)
                       .Select(a => new StatisticsDto()
                       {
                           id = a.Key,
                           total = a.Sum(b => b.YellowCards),
                           name = a.Where(b => b.Id == a.Key).Select(b => b.Name).FirstOrDefault(),
                           teamName = a.Where(b => b.Id == a.Key).Select(b => b.TeamName).FirstOrDefault()
                       }).ToList();
            res.AddRange(res2);
            return res;
        }

        public List<MinutesDto> GetMinutes()
        {
            var res = context.Players
                        .Where(a => a.MinutesPlayed > 0)
                        .ToList().GroupBy(a => a.Id)
                       .Select(a => new MinutesDto()
                       {
                           id = a.Key,
                           total = a.Sum(b => b.MinutesPlayed),
                           name = a.Where(b => b.Id == a.Key).Select(b => b.Name).FirstOrDefault(),
                           tipo = "Player"
                       }).ToList();

            var res2 = context.Refrees
                        .Where(a => a.MinutesPlayed > 0)
                        .ToList().GroupBy(a => a.Id)
                       .Select(a => new MinutesDto()
                       {
                           id = a.Key,
                           total = a.Sum(b => b.MinutesPlayed),
                           name = a.Where(b => b.Id == a.Key).Select(b => b.Name).FirstOrDefault(),
                           tipo = "Referee"
                       }).ToList();
            res.AddRange(res2);

            return res;
        }
    }
}

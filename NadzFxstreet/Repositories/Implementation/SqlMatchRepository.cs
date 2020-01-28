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
    public class SqlMatchRepository : ISqlMatchRepository
    {
        private readonly FxStreetDemoCtx context;

        public SqlMatchRepository(FxStreetDemoCtx context)
        {
            this.context = context;
        }

        public Match Add(Match Match)
        {
            context.Matches.Add(Match);
            context.SaveChanges();
            return Match;
        }

        public Match Delete(int Id)
        {
            Match Match = context.Matches.Find(Id);
            if (Match != null)
            {
                context.Matches.Remove(Match);
                context.SaveChanges();
            }
            return Match;
        }


        public List<Match> GetAllMatches()
        {
            return this.context.Matches.ToList();
        }


        public Match GetMatch(int Id)
        {
            return context.Matches.Find(Id);
        }

        public Match GetMatchById(int Id)
        {
            return context.Matches.Find(Id);

        }

        public Match Update(Match MatchChanges)
        {
            var Match = context.Matches.Attach(MatchChanges);
            Match.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return MatchChanges;
        }

        public void RemovePlayer(List<PlayersOfMatch> players)
        {
            context.PlayersOfMatch.RemoveRange(players);
        }
    }
}

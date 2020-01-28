using Demo.PersistenceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Repositories.Interfaces
{
    public interface ISqlMatchRepository
    {
        Match GetMatchById(int Id);
        List<Match> GetAllMatches();
        Match Add(Match Match);
        Match Update(Match MatchChanges);
        Match Delete(int Id);
        void RemovePlayer(List<PlayersOfMatch> players);
    }
}

using Demo.PersistenceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Repositories.Interfaces
{
    public interface ISqlRefereeRepository
    {
        Referee GetRefereeById(int Id);
        List<Referee> GetAllReferees();
        Referee Add(Referee Referee);
        Referee Update(Referee RefereeChanges);
        Referee Delete(int Id);
    }
}

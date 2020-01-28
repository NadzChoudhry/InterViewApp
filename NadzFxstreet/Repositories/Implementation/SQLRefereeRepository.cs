using Demo.PersistenceLayer;
using Demo.PersistenceLayer.Models;
using NadzFxstreet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NadzFxstreet.Repositories.Implementation
{
    public class SqlRefereeRepository : ISqlRefereeRepository
    {
        private readonly FxStreetDemoCtx context;

        public SqlRefereeRepository(FxStreetDemoCtx context)
        {
            this.context = context;
        }

        public Referee Add(Referee Referee)
        {
            context.Refrees.Add(Referee);
            context.SaveChanges();
            return Referee;
        }

        public Referee Delete(int Id)
        {
            Referee Referee = context.Refrees.Find(Id);
            if (Referee != null)
            {
                context.Refrees.Remove(Referee);
                context.SaveChanges();
            }
            return Referee;
        }

        public List<Referee> GetAllReferees()
        {
            return this.context.Refrees.ToList();
        }

        public Referee GetReferee(int Id)
        {
            return context.Refrees.Find(Id);
        }

        public Referee GetRefereeById(int Id)
        {
            return context.Refrees.Find(Id);
        }

        public Referee Update(Referee RefereeChanges)
        {
            var Referee = context.Refrees.Attach(RefereeChanges);
            Referee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return RefereeChanges;
        }
    }
}

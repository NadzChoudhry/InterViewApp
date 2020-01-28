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
    public class SQLManagerRepository : ISQLManagerRepository
    {
        private readonly FxStreetDemoCtx context;

        public SQLManagerRepository(FxStreetDemoCtx context)
        {
            this.context = context;
        }

        public Manager Add(Manager Manager)
        {
            context.Managers.Add(Manager);
            context.SaveChanges();
            return Manager;
        }

        public Manager Delete(int Id)
        {
            Manager Manager = context.Managers.Find(Id);
            if (Manager != null)
            {
                context.Managers.Remove(Manager);
                context.SaveChanges();
            }
            return Manager;
        }


        public List<Manager> GetAllManagers()
        {
            return this.context.Managers.ToList();
        }

        public Manager GetManager(int Id)
        {
            return context.Managers.Find(Id);
        }

        public Manager GetManagerById(int Id)
        {

            return context.Managers.Where(m => m.Id == Id).FirstOrDefault();
        }

        public ManagerDto GetManageDtoById(int Id)
        {
            return context.Managers.Where(m => m.Id == Id).Select(m => new ManagerDto()
            {
                name = m.Name,
                redCards = m.RedCards,
                yellowCards = m.YellowCards,
                teamName = m.TeamName
            }).FirstOrDefault();


        }

        public Manager Update(Manager ManagerChanges)
        {
            var Manager = context.Managers.Attach(ManagerChanges);
            Manager.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ManagerChanges;
        }


    }
}

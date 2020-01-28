using Demo.PersistenceLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PersistenceLayer.Utils
{
    public static class Dbhelper
    {
        #region Managers
        public static List<Manager> GetManagers()
        {
            List<Manager> lista;
            using (var ctx = new FxStreetDemoCtx())
            {
                lista = ctx.Managers
                    .ToList();
            }
            return lista;
        }

        public static Manager GetManagerById(int id)
        {
            Manager lista;
            using (var ctx = new FxStreetDemoCtx())
            {
                lista = ctx.Managers
                    .Where(m => m.Id == id)
                    .FirstOrDefault();
            }
            return lista;
        }


        public static Manager ModifyManagers(Manager manager)
        {
            Manager m;
            using (var ctx = new FxStreetDemoCtx())
            {
                m = ctx.Managers.Find(manager.Id);
                m = manager;
                ctx.Entry<Manager>(m).State = EntityState.Modified;
                ctx.SaveChanges();

            }
            return m;
        }

        public static bool DeleteManager(int id)
        {
            Manager m;
            var res = false;
            using (var ctx = new FxStreetDemoCtx())
            {
                m = ctx.Managers.Find(id);
                ctx.Managers.Remove(m);
                ctx.SaveChanges();
                res = true;
            }
            return res;
        }
        #endregion
        public static List<Player> GetPlayers()
        {
            List<Player> lista;
            using (var ctx = new FxStreetDemoCtx())
            {
                lista = ctx.Players
                    .ToList();
            }
            return lista;
        }
        #region Player


        #endregion

        #region Matches
        #endregion

        #region Regeree
        #endregion

        #region Statistics
        #endregion
    }
}

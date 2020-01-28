using Demo.PersistenceLayer.Models;
using NadzFxstreet.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Repositories.Interfaces
{
    public interface ISQLManagerRepository
    {
        Manager GetManagerById(int Id);
        ManagerDto GetManageDtoById(int Id);
        List<Manager> GetAllManagers();
        Manager Add(Manager Manager);
        Manager Update(Manager ManagerChanges);
        Manager Delete(int Id);
    }


}

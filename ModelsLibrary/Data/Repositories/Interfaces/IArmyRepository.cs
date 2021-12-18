using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface IArmyRepository : IRepository<Army>
    {
        Task<Army> GetArmyByIdWithPopulatedLists(int id);
    }
}

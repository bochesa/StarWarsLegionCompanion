using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Data.Repositories;

namespace UtilityLibrary.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitRepository Units { get; }
        IWeaponRepository Weapons { get; }
        Task<int> Complete();
    }
}

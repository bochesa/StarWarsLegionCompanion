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
        IUpgradeRepository Upgrades { get; }
        IUnitRepository Units { get; }
        IWeaponRepository Weapons { get; }
        IKeywordRepository Keywords { get; }
        ICommandRepository Commands { get; }
        IArmyRepository Armies { get; }
        Task<int> Complete();
    }
}

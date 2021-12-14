using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Data.Repositories;
using UtilityLibrary.Data.SWContext;

namespace UtilityLibrary.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;

            Units = new UnitRepository(_context);
            Weapons = new WeaponRepository(_context);
            Keywords = new KeywordRepository(_context);
            Upgrades = new UpgradeRepository(_context);
            Commands = new CommandRepository(_context);
        }
        public IUnitRepository Units { get; private set; }
        public IWeaponRepository Weapons { get; private set; }
        public IKeywordRepository Keywords { get; private set; }
        public IUpgradeRepository Upgrades { get; private set; }
        public ICommandRepository Commands { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

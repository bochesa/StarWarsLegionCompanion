using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<Unit> GetUnitByIdWithPopulatedLists(int id)
        {
            var unit = await _context.Set<Unit>().Where(u => u.Id == id)
                .Include(u => u.Weapons).ThenInclude(w => w.AttackValue)
                .Include(u => u.Weapons).ThenInclude(w => w.Keywords)
                .Include(u => u.Keywords)
                .Include(u => u.UpgradeOptions)
                .SingleAsync();
            return unit;
        }
    }
    public class UpgradeRepository : Repository<Upgrade>, IUpgradeRepository
    {
        public UpgradeRepository(ApplicationContext context) : base(context)
        {

        }
    }
}


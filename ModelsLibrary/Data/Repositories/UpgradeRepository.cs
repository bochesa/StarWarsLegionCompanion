using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class UpgradeRepository : Repository<Upgrade>, IUpgradeRepository
    {
        public UpgradeRepository(ApplicationContext context) : base(context)
        {

        }
        public async Task<Upgrade> GetUpgradeByIdWithPopulatedLists(int id)
        {
            var upgrade = await _context.Set<Upgrade>().Where(u => u.Id == id)
                .Include(u => u.Weapon).ThenInclude(w => w.AttackValue)
                .Include(u => u.Weapon).ThenInclude(w => w.Keywords)
                .Include(u => u.Keywords)
                .SingleAsync();
            return upgrade;
        }
    }
}


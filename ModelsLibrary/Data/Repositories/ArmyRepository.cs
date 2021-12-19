using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{

    public class ArmyRepository : Repository<Army>, IArmyRepository
    {
        public ArmyRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<Army> GetArmyByIdWithPopulatedLists(int id)
        {
            var army = await _context.Set<Army>().Where(A => A.Id == id)
                .Include(a => a.ChosenCommands).ThenInclude(c => c.Command)
                .Include(a => a.ChosenUnits).ThenInclude(c => c.Unit)
                .Include(a => a.ChosenUnits).ThenInclude(x => x.ChosenUpgrades).ThenInclude(u => u.Upgrade)
                .Include(a => a.Player)
                .SingleAsync();
            return army;
        }


    }

}


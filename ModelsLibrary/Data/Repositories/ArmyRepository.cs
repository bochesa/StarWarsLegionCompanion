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
        public async Task<ChosenUnit> GetChosenUnitById(int chosenUnitId)
        {
            var chosenUnit = await _context.Set<ChosenUnit>().Where(c => c.Id == chosenUnitId)
                .Include(c => c.ChosenUpgrades)
                .SingleAsync();

            return chosenUnit;
        }
        public async Task RemoveCommand(int ChosenCommandId)
        {
            var chosenCommand = await _context.Set<ChosenCommand>().Where(c => c.Id == ChosenCommandId).SingleAsync();
            _context.Set<ChosenCommand>().Remove(chosenCommand);
        }
        public async Task RemoveUnit(int ChosenUnitId)
        {
            var chosenUnit = await _context.Set<ChosenUnit>().Where(c => c.Id == ChosenUnitId)
                .Include(x => x.ChosenUpgrades)
                .SingleAsync();
            if (chosenUnit.ChosenUpgrades.Count != 0)
            {
                foreach (var chosenUpgrade in chosenUnit.ChosenUpgrades)
                {
                    await RemoveUpgrade(chosenUpgrade.Id);
                }
            }
            _context.Set<ChosenUnit>().Remove(chosenUnit);
        }

        public async Task RemoveUpgrade(int ChosenUpgradeId)
        {
            var chosenUpgrade = await _context.Set<ChosenUpgrade>().Where(c => c.Id == ChosenUpgradeId).SingleAsync();
            _context.Set<ChosenUpgrade>().Remove(chosenUpgrade);
        }

    }

}


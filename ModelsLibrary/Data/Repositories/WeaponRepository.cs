using System.Linq;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UtilityLibrary.Data.Repositories
{
    public class WeaponRepository : Repository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<Weapon> GetWeaponByName(string name)
        {
            Weapon weapon = await _context.Set<Weapon>().FirstOrDefaultAsync(w => w.Name == name);
            return weapon;
        }

    }

}


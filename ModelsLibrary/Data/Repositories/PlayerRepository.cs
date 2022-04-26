using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Player> GetPlayerWithArmies(int id)
        {
            var player = await _context.Set<Player>().Where(x => x. Id == id).SingleAsync();
            return player;
        }
    }

}


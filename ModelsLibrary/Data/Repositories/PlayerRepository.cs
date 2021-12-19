using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationContext context) : base(context)
        {

        }
    }

}


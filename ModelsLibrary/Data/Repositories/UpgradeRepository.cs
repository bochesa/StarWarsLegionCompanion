using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class UpgradeRepository : Repository<Upgrade>, IUpgradeRepository
    {
        public UpgradeRepository(ApplicationContext context) : base(context)
        {

        }
    }
}


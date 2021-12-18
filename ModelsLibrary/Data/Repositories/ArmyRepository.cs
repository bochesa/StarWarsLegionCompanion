using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class ArmyRepository : Repository<Army>, IArmyRepository
    {
        public ArmyRepository(ApplicationContext context) : base(context)
        {

        }
    }

}


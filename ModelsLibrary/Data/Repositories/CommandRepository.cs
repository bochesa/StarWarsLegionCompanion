using Microsoft.EntityFrameworkCore;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class CommandRepository : Repository<Command>, ICommandRepository
    {
        public CommandRepository(ApplicationContext context) : base(context)
        {
        }
    }
}


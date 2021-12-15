using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public class CommandRepository : Repository<Command>, ICommandRepository
    {
        public CommandRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Command> GetCommandByIdWithUnit(int id)
        {
            var command = await _context.Set<Command>().Where(c => c.Id == id)
                .Include(c => c.Unit)
                .SingleAsync();
            return command;
        }
    }
}


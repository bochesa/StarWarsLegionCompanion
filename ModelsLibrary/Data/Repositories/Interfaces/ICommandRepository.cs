using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface ICommandRepository : IRepository<Command>
    {
        Task<Command> GetCommandByIdWithUnit(int id);
    }
}

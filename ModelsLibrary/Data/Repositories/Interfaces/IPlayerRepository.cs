using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> GetPlayerWithArmies(int id);
        // Task<Player> GetPlayerWithCollection(int id)

    }
}

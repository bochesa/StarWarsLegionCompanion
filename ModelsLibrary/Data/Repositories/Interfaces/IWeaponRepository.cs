using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface IWeaponRepository : IRepository<Weapon>
    {

        Task<Weapon> GetWeaponByName(string name);
    }
}

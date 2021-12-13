using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface IWeaponRepository : IRepository<Weapon>
    {
        Task<bool> WeaponExist(string name);
        Task<Weapon> GetWeaponByName(string name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface IKeywordRepository : IRepository<Keyword>
    {
        Task<bool> KeywordExist(string name);
        Task<Keyword> GetKeywordByName(string name);
    }
}

using UtilityLibrary.Data.SWContext;
using UtilityLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UtilityLibrary.Data.Repositories
{
    public class KeywordRepository : Repository<Keyword>, IKeywordRepository
    {
        public KeywordRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<Keyword> GetKeywordByName(string name)
        {
            Keyword keyword = await _context.Set<Keyword>().FirstOrDefaultAsync(w => w.Name == name);
            return keyword;
        }

        public async Task<bool> KeywordExist(string name)
        {
            bool keyword = await _context.Set<Keyword>().AnyAsync(w => w.Name == name);
            return keyword;

        }
    }

}


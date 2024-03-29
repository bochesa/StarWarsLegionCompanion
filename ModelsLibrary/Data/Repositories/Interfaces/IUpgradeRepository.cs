﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Data.Repositories
{
    public interface IUpgradeRepository : IRepository<Upgrade>
    {
        Task<Upgrade> GetUpgradeByIdWithPopulatedLists(int id);
    }
}

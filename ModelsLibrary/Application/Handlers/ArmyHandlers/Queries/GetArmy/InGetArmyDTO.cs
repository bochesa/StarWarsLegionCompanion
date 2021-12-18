using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetArmyDTO : IRequest<OutGetArmyDTO>
    {
        public int Id { get; set; }
    }
    public class OutGetArmyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Player Player { get; set; }
        public virtual FactionType Faction { get; set; }
        public int PointLimit { get; set; }
        public List<Command> Commands { get; set; }
        public List<Models.Unit> Units { get; set; }
        public List<Upgrade> Upgrades { get; set; }
    }
    public class GetArmyHandler : IRequestHandler<InGetArmyDTO, OutGetArmyDTO>
    {
        public Task<OutGetArmyDTO> Handle(InGetArmyDTO request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

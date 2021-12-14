using MediatR;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetUpgradeDTO : IRequest<OutGetUpgradetDTO>
    {
        public int Id { get; set; }
    }
}

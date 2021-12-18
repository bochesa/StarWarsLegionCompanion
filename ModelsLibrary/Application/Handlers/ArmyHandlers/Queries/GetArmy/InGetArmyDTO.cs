using MediatR;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InGetArmyDTO : IRequest<OutGetArmyDTO>
    {
        public int Id { get; set; }
    }
}

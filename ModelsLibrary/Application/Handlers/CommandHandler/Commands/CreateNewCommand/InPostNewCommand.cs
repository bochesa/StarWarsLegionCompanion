using MediatR;

namespace UtilityLibrary.Application.Handlers
{
    public class InPostNewCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int Pips { get; set; }
        public string Text { get; set; }
        public string Orders { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InUpdateUnitNameDTO : IRequest<int>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}

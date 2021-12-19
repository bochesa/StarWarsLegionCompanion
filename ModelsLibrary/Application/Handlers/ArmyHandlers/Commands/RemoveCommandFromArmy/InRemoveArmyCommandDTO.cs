﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityLibrary.Application.Handlers
{
    public class InRemoveArmyCommandDTO : IRequest<int>
    {
        //public int ArmyId { get; set; }
        public int ChosenCommandId { get; set; }
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Application.Services;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class GetPlayerHandler : IRequestHandler<InGetPlayerDTO, OutGetPlayerDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IDTOServices _services;

        public GetPlayerHandler(IUnitOfWork uow, IDTOServices services)
        {
            _uow = uow;
            _services = services;
        }

        public async Task<OutGetPlayerDTO> Handle(InGetPlayerDTO request, CancellationToken cancellationToken)
        {
            // get Player from _uow
            var player = await _uow.Players.GetPlayerWithArmies(request.Id);
            // Create Out DTO
            
            OutGetPlayerDTO playerDto = new OutGetPlayerDTO
            {
                Id = player.Id,
                Armies
            }

            return playerDto;
        }
    }
}
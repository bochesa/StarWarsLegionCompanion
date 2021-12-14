using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;

namespace UtilityLibrary.Application.Handlers
{
    public class GetAllCommandsHandler : IRequestHandler<InGetAllCommandsDTO, List<OutGetAllCommandsDTO>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllCommandsHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<OutGetAllCommandsDTO>> Handle(InGetAllCommandsDTO request, CancellationToken cancellationToken)
        {
            var commands = await _uow.Commands.GetAll();
            List<OutGetAllCommandsDTO> OutDto = new();

            foreach (var item in commands)
            {
                OutGetAllCommandsDTO commandDto = new OutGetAllCommandsDTO
                {
                    Name = item.Name,
                    Id = item.Id
                };
                OutDto.Add(commandDto);
            }

            return OutDto;
        }
    }
    public class InGetAllCommandsDTO : IRequest<List<OutGetAllCommandsDTO>>
    {
    }
    public class OutGetAllCommandsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

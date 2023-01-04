using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary.Data.UnitOfWork;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class GetAllKeywordsHandler : IRequestHandler<InGetAllKeywordsDTO, List<OutGetAllKeywordsDTO>>
    {
        private readonly IUnitOfWork _uow;
        public GetAllKeywordsHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<OutGetAllKeywordsDTO>> Handle(InGetAllKeywordsDTO request, CancellationToken cancellationToken)
        {
            var keywordsData = await _uow.Keywords.GetAll();
            List<OutGetAllKeywordsDTO> keywordsDtos = new();

            foreach (var keyword in keywordsData)
            {
                OutGetAllKeywordsDTO keywordDto = new OutGetAllKeywordsDTO
                {
                    Id = keyword.Id,
                    Name = keyword.Name,
                    AbilityValue = keyword.AbilityValue,
                    KeywordType = (int)keyword.KeywordType,
                    ShortDescription = keyword.ShortDescription,
                    LongDescription= keyword.LongDescription,
                    ActionType = (int)keyword.ActionType
                };
                keywordsDtos.Add(keywordDto);
            }

            return keywordsDtos;
        }

    }
}

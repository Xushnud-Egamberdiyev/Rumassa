using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.DiplomCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.DiplomCases.Handlers.QueriesHandler
{
    public class GetAllDiplomsByIdQueryHandler : IRequestHandler<GetAllDiplomsByIdQuery, Diplom>
    {
        private readonly IRumassaDbContext _context;

        public GetAllDiplomsByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Diplom> Handle(GetAllDiplomsByIdQuery request, CancellationToken cancellationToken)
        {
            var diplom = await _context.Diploms.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (diplom != null)
            {
                return diplom;
            }
            throw new Exception("Diplom Not Found!");
        }
    }
}

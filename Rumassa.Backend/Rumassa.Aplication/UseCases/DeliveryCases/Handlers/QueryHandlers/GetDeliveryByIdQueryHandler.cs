using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.DeliveryCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.DeliveryCases.Handlers.QueryHandlers
{
    public class GetDeliveryByIdQueryHandler : IRequestHandler<GetDeliveryByIdQuery, Delivery>
    {
        private readonly IRumassaDbContext _context;

        public GetDeliveryByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery> Handle(GetDeliveryByIdQuery request, CancellationToken cancellationToken)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (delivery != null)
            {
                return delivery;
            }

            throw new Exception("Delivery Not Found!");
        }
    }
}

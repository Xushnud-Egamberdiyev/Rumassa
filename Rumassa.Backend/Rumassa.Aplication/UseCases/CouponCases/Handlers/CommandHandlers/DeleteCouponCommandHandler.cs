using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.CouponCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.CouponCases.Handlers.CommandHandlers
{
    public class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteCouponCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Coupon Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Coupon is not found",
                StatusCode = 400
            };
        }
    }
}

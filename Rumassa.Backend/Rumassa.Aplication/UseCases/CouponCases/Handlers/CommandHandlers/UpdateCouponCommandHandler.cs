using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.CouponCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.CouponCases.Handlers.CommandHandlers
{
    public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public UpdateCouponCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (coupon != null)
            {
                coupon.Code = request.Code;
                coupon.ExpireDate = request.ExpireDate;
                coupon.Limit = request.Limit;
                coupon.Percent = request.Percent;

                _context.Coupons.Update(coupon);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Coupon Updated",
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

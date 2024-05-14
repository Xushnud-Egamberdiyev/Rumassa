using MediatR;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.CouponCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.CouponCases.Handlers.CommandHandlers
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public CreateCouponCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var coupon = new Coupon()
                {
                    Code = request.Code,
                    ExpireDate = request.ExpireDate,
                    Limit = request.Limit,
                    Percent = request.Percent,
                };

                await _context.Coupons.AddAsync(coupon, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Coupon Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Coupon is might be null",
                StatusCode = 400
            };
        }
    }
}

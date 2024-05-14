using MediatR;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.ReviewCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.ReviewCases.Handlers.CommandHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ResponseModel>
    {

        private readonly IRumassaDbContext _context;

        public CreateReviewCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var review = new Review()
                {
                    Username = request.Username,
                    Email = request.Email,
                    Text = request.Text,
                    ProductId = request.ProductId,
                };

                await _context.Reviews.AddAsync(review, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Review Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Review is might be null",
                StatusCode = 400
            };
        }

    }
}

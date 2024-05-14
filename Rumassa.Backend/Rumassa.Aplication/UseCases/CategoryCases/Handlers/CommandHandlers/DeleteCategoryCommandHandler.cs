using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Aplication.UseCases.CategoryCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Handlers.CommandHandlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseModel>
{
    private readonly IRumassaDbContext context;

    public DeleteCategoryCommandHandler(IRumassaDbContext context) =>
        this.context = context;
    

    public async Task<ResponseModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (category is not null)
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = $"{category} Deleted",
                StatusCode = 201,
                IsSuccess = true
            };
        }

        return new ResponseModel
        {
            Message = "Category is not found",
            StatusCode = 200,
        };
    }
}

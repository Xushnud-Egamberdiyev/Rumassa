using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Aplication.UseCases.CategoryCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Handlers.CommandHandlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResponseModel>
{
    private readonly IRumassaDbContext context;

    public UpdateCategoryCommandHandler(IRumassaDbContext context) =>
        this.context = context;
    

    public async Task<ResponseModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

        if(category is not null)
        {
            category.Name = request.Name;

            context.Categories.Update(category);

            await context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = "Category Updated",
                StatusCode = 201,
                IsSuccess = true
            };
        }

        return new ResponseModel
        {
            Message = "Category is not found",
            StatusCode = 404
        };
    }
}

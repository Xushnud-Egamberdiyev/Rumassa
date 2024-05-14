using MediatR;
using Rumassa.Aplication.Abstraction;
using Rumassa.Aplication.UseCases.CategoryCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Handlers.CommandHandlers;

public class CreateCategoryCommandHandlers : IRequestHandler<CreateCategoryCommand, ResponseModel>
{
    private readonly IRumassaDbContext context;

    public CreateCategoryCommandHandlers(IRumassaDbContext context) =>
        this.context = context;
    

    public async Task<ResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if(request is not null)
        {
            var category = new Category()
            {
                Name = request.Name
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = $"{category} Created.",
                StatusCode = 200,
                IsSuccess = true
            };
        }

        return new ResponseModel
        {
            Message = "Category is might be null",
            StatusCode = 400
        };
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Aplication.UseCases.CategoryCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Aplication.UseCases.CategoryCases.Handlers.QueryHandlers;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly IRumassaDbContext context;

    public GetByIdCategoryQueryHandler(IRumassaDbContext context)
    {
        this.context = context;
    }

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

        if(category is not null)
        {
            return category;
        }

        throw new  Exception("Category Not Found!");
    }
}

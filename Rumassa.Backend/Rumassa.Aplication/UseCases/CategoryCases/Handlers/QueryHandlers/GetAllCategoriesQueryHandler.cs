using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Aplication.UseCases.CategoryCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Aplication.UseCases.CategoryCases.Handlers.QueryHandlers;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly IRumassaDbContext context;

    public GetAllCategoriesQueryHandler(IRumassaDbContext context) =>
        this.context = context;
    

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await context.Categories.ToListAsync(cancellationToken);
    }
}

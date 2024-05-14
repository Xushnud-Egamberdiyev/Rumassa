using MediatR;
using Rumassa.Domain.Entities;

namespace Rumassa.Aplication.UseCases.CategoryCases.Queries;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public short Id { get; set; }
}

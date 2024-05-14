using MediatR;
using Rumassa.Domain.Entities;

namespace Rumassa.Aplication.UseCases.CategoryCases.Queries;

public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
{
}

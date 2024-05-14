using MediatR;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Commands;

public class CreateCategoryCommand : IRequest<ResponseModel>
{
    public string Name { get; set; }
}

using MediatR;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Commands;

public class UpdateCategoryCommand : IRequest<ResponseModel>
{
    public short Id { get; set; }
    public string Name { get; set; }
}

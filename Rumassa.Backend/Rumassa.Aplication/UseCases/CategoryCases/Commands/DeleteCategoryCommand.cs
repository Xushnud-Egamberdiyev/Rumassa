using MediatR;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Commands;

public class DeleteCategoryCommand : IRequest<ResponseModel>
{
    public short Id { get; set; }   
}

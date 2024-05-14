using MediatR;
using Rumassa.Aplication.UseCases.CategoryCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Aplication.UseCases.CategoryCases.Handlers.CommandHandlers;

public class CreateCategoryCommandHandlers : IRequestHandler<CreateCategoryCommand, ResponseModel>
{
    public Task<ResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Aplication.Abstraction;
using Rumassa.Application.UseCases.CommentCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.CommentCases.Handlers.QueryHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly IRumassaDbContext _context;

        public GetCommentByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment != null)
            {
                return comment;
            }

            throw new Exception("Comment Not Found!");
        }
    }
}

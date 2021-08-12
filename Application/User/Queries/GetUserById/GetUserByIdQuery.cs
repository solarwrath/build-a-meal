using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.User.Queries.GetUserByID
{
    public record GetUserByIdQuery : IRequest<GetUserByIdResult>
    {
        public int UserId { get; init;  }
    }

    public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResult>
    {
/*
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            
            public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
*/
        public Task<GetUserByIdResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserByIdResult
            {
                UserName = $"Username {request.UserId}"
            });
        }
    }

    public class GetUserByIdResult
    {
        public string UserName { get; set; }
    }
}
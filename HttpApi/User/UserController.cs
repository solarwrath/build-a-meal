using MediatR;

namespace RestApi.User
{
    public partial class UserController: HttpApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
    }
}
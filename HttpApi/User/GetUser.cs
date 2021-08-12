using System.Threading.Tasks;
using Application.User.Queries.GetUserByID;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.User
{
    public record GetUserApiRequest
    {
        public int UserId { get; init; }
    }

    public partial class UserController
    {
        [HttpGet]
        public async Task<GetUserApiResponse> GetUser([FromQuery] GetUserApiRequest request)
        {
            GetUserByIdResult result = await _mediator.Send(new GetUserByIdQuery
            {
                UserId = request.UserId
            });

            return new GetUserApiResponse
            {
                Name = result.UserName
            };
        }
    }

    public class GetUserApiResponse
    {
        public string Name { get; set; }
    }
}
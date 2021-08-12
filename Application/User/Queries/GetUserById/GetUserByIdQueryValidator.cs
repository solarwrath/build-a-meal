using FluentValidation;

namespace Application.User.Queries.GetUserByID
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserID should be greater than 0.");
        }
    }
}
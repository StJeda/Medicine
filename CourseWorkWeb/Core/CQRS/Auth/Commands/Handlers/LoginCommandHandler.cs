using CourseWorkWeb.Core.Auth;
using CourseWorkWeb.Core.CQRS.Auth.Commands.Commands;
using CourseWorkWeb.Core.CQRS.Auth.Queries.Queries;
using CourseWorkWeb.DAL.Jwt;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Auth.Commands.Handlers
{
    public class LoginCommandHandler(ISender sender,IPasswordHasher hasher, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, string>
    {
        private readonly ISender _sender = sender;
        private readonly IPasswordHasher _hasher = hasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _sender.Send(new GetUserByEmailQuery(request.email)).Result;
                var result = _hasher.Verify(request.password, user.Password.PasswordValue);
                if (!result)
                    throw new InvalidOperationException("Bad login");
                string token = _jwtProvider.GenerateToken(user);
                if (token is null)
                    throw new InvalidDataException();
                return Task.FromResult(token);
            }
            catch(InvalidOperationException ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult("");
            }
            catch(InvalidDataException ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult("");
            }
        }
    }
}

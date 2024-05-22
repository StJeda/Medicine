using CourseWorkWeb.Models.Entity.Auth;

namespace CourseWorkWeb.DAL.Jwt
{
    public interface IJwtProvider
    {
        public string GenerateToken(Account user);
    }
}

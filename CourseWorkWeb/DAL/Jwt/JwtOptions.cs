namespace CourseWorkWeb.DAL.Jwt
{
    public class JwtOptions
    {
        public JwtOptions()
        {
            
        }
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiresHours { get; set; }
    }
}

using _03.JsonWebToken.Models.ORM;

namespace _03.JsonWebToken.Models.Auth
{
    public class WebUser : BaseEntity
    {
        public string Password { get; set; }
        public string EMail { get; set; }
    }
}

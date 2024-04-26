using _03.JsonWebToken.Models.Auth;
using _03.JsonWebToken.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03.JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ECommerceContext db;

        public AuthController(ECommerceContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            var userCheck = db.WebUsers.FirstOrDefault(x => x.EMail == model.EMail && x.Password == model.Password && x.IsDeleted == false);

            if (userCheck != null)
            {
                AcademyTokenHandler academyTokenHandler = new AcademyTokenHandler();
                Token token = academyTokenHandler.CreateAccessToken();

                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}


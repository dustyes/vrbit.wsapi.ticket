using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vrbit.wsapi.ticket.Business;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;

        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            return _loginBusiness.FindByLogin(user);
        }
    }
}

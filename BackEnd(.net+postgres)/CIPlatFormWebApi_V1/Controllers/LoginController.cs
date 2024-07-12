using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Data_Logic_Layer.UserAndLoginEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public BALLogin _balLogin;

        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }

        ResponseResult result = new ResponseResult();
        [HttpPost]
        public ResponseResult LoginUser(LoginRequest login)
        {
            try
            {
                result.Data = _balLogin.LoginUser(login.Email,login.Password);
                result.Result = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
        
    }
}

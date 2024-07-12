using Business_Logic_Layer.JWTService;
using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALLogin
    {
        public DALLogin _dalLogin;
        public JwtService _jwtService;

        public BALLogin(DALLogin dalLogin , JwtService jwtService)
        {
            _dalLogin = dalLogin;
            _jwtService = jwtService;
        }

        ResponseResult result = new ResponseResult();
        public ResponseResult LoginUser(string email,string password)
        {
            try
            {
                User userObj = new User();
                userObj = _dalLogin.LoginUser(email,password);
                if (userObj != null)
                {
                    if(userObj.Message.ToString() == "Login Successfully")
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Success;
                        result.Data = _jwtService.GenerateToken(email,userObj.UserType);
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error in login";
                    result.Result = ResponseStatus.Success;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

       

    }
}

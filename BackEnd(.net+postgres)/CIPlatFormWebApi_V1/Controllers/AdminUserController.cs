﻿using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly BALAdminUser _balAdminUser;

        public AdminUserController(BALAdminUser balAdminUser)
        {
            _balAdminUser = balAdminUser;
        }

        [HttpPost]
      //  [Authorize(Roles = "admin")]
        [Route("AddUser")]
        public ResponseResult AddUser(User user)
        {
            try
            {
                result.Data = _balAdminUser.AddUser(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        [HttpGet]
       // [Authorize(Roles = "admin")]
        [Route("UserDetailList")]
        public ResponseResult GetUserDetailList()
        {
            try
            {
                result.Data = _balAdminUser.GetUserList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        [HttpPost]
        [Route("DeleteUser")]
      //  [Authorize(Roles = "admin")]
        public async Task<ResponseResult> DeleteUser(int userId)
        {
            try
            {
                result.Data = await _balAdminUser.DeleteUser(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateUser")]
       // [Authorize(Roles = "admin")]
        public ResponseResult UpdateUser(string email,string fname,string lname,string phone)
        {
            User user = new User();
            user.FirstName = fname;
            user.LastName = lname;
            user.PhoneNumber = phone;
            user.EmailAddress = email;
            
            try
            {
                result.Data = _balAdminUser.UpdateUser(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}
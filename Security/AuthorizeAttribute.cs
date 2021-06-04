using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using SchoolManagement.API.Models;
namespace SchoolManagament.API.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _roleID;
        public AuthorizeAttribute()
        {
            _roleID = 0;
        }
        public AuthorizeAttribute(int roleID)
        {
            _roleID = roleID;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else if(user.RoleId != _roleID)
            {
                context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
            }
        }
    }
}
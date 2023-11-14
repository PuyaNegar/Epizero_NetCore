using Common.Enums;
using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace TeacherPresentationLayer.Infrastracture.Functions
{
    public static class CurrentContext
    {
        //=======================================================================================
        public static int GetCurrentUsername(ControllerBase controllerBase)
        {
            return Convert.ToInt32(controllerBase.User.Claims.ToList()[0].Value);
        }
        //=======================================================================================
        public static int? GetCurrentUserId(ControllerBase controllerBase)
        {
            try
            {
                return Convert.ToInt32(controllerBase.User.Claims.ToList()[1].Value);
            }
            catch (Exception)
            {
                return null; 
            }
        } 
        //=======================================================================================
        public static UserGroup GetCurrentUserGroup(ControllerBase controllerBase)
        {
            return (UserGroup)Convert.ToInt32(controllerBase.User.Claims.ToList()[2].Value);
        }
        //=======================================================================================
    }
}

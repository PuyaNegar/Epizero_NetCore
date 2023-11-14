using Common.Enums;
using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebPresentationLayer.Infrastracture.Functions
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
        public static int GetOrderId(ControllerBase controllerBase)
        {
            var cookieHashId = controllerBase.Request.Cookies["OrderHashId"] == null ? string.Empty : controllerBase.Request.Cookies["OrderHashId"].ToString();
            if (string.IsNullOrEmpty(cookieHashId))
                return 0;
            else 
                return Convert.ToInt32(cookieHashId.DecriptWithDESAlgoritm());
        }
        //=======================================================================================
        public static string GetOrderHashId(ControllerBase controllerBase)
        {
            var cookieHashId = controllerBase.Request.Cookies["OrderHashId"] == null ? string.Empty : controllerBase.Request.Cookies["OrderHashId"].ToString();
            if (string.IsNullOrEmpty(cookieHashId))
                return null;
            else
                return cookieHashId;
        }
        //=======================================================================================
        public static UserGroup GetCurrentUserGroup(ControllerBase controllerBase)
        {
            return (UserGroup)Convert.ToInt32(controllerBase.User.Claims.ToList()[2].Value);
        }
        //=======================================================================================
    }
}

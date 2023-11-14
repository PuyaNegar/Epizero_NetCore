﻿using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace PanelPresentationLayer.Infrastracture.Functions
{
    public static class CurrentContext
    {
        //=======================================================================================
        public static int GetCurrentUsername(ControllerBase controllerBase)
        {
            return Convert.ToInt32(controllerBase.User.Claims.ToList()[0].Value);
        }
        //=======================================================================================
        public static int GetCurrentUserId(ControllerBase controllerBase)
        {
            return Convert.ToInt32(controllerBase.User.Claims.ToList()[1].Value);
        }
        //=======================================================================================
        public static UserGroup GetCurrentUserGroup(ControllerBase controllerBase)
        {
            return (UserGroup)Convert.ToInt32(controllerBase.User.Claims.ToList()[2].Value);
        }
        //=======================================================================================
    }
}

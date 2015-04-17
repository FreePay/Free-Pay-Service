using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreePayService.Security
{
    public class UserClaimValidator
    {
        public bool HasRightsForAddress(string userName, string uri)
        {
            return userName.Equals("Pavel");
        }
    }
}
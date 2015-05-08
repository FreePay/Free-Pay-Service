using FreePayService.Data;
using FreePayService.Models;
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
            using (PaymentsContext context = new PaymentsContext())
            {
                UserInfo user = context.Users.Where(u => u.Name.Equals(userName)).FirstOrDefault();
                WebServiceInfo service = context.WebServices.Where(u => u.Uri.Equals(uri)).FirstOrDefault();

                if (user == null || service == null)
                {
                    return false;
                }

                int userId = user.UserInfoId;
                int serviceId = service.WebServiceInfoId;

                return context.Payments.Any(p => p.ServiceId == serviceId && p.UserId == userId);
            }
        }
    }
}
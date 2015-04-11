using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FreePayService.Models;

namespace FreePayService.Data
{
    public class PaymentsContext : DbContext
    {
        public DbSet<WebServiceInfo> WebServices { get; set; }
    }
}
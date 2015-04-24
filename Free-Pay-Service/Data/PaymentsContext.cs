using FreePayService.Models;
using System.Data.Entity;

namespace FreePayService.Data
{
    public class PaymentsContext : DbContext
    {
        public DbSet<WebServiceInfo> WebServices { get; set; }
    }
}
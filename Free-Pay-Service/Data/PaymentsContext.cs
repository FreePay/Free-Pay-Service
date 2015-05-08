using FreePayService.Models;
using System.Data.Entity;

namespace FreePayService.Data
{
    public class PaymentsContext : DbContext
    {
        public DbSet<WebServiceInfo> WebServices { get; set; }
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }
    }
}
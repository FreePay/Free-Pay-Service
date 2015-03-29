using FreePayService.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace FreePayService
{
    public class PaymentService : IPaymentService
    {
        public String GetMessage()
        {
            String name = "unknown";
            using (var context = new PaymentsContext())
            {
                name = context.Persons.ToList().First().Name;
            }
            return "Hello from " + name;
        }
    }

    public class PaymentsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}

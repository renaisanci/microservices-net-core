using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {

        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
                orderContext.Database.Migrate();
                //orderContext.Database.EnsureCreated();

                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreconfiguredOrders());
                    await orderContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }
                throw;
            }

        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order() { UserName = "rnt", FirstName = "Renato", LastName = "Foseca", EmailAddress = "rnt@gmail.com", AddressLine = "Bahcelievler", TotalPrice = 5239 },
                new Order() { UserName = "mia", FirstName = "Maiara", LastName = "Velozo", EmailAddress ="mia@gmail.com", AddressLine = "Ferah", TotalPrice = 3486 }
            };
        }
    }
}

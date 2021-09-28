using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindEntityLocalData.Data;
using NorthWindEntityLocalData.Projections;

namespace NorthWindEntityLocalData.Classes
{
    public class CustomersOperations
    {
        public static async Task<List<CustomerItem>> GetCustomersWithProjectionAsync()
        {

            return await Task.Run(async () =>
            {
                await using var context = new NorthContext();
                return await context.Customers
                    .Select(CustomerItem.Projection)
                    .ToListAsync();
            });
        }

        public static void Warmup()
        {
            using var context = new NorthContext();
            var _ = context.Customers.Count();
        }
    }
}

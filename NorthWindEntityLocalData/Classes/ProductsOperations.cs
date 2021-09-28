using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindEntityLocalData.Data;
using NorthWindEntityLocalData.Models;
using NorthWindEntityLocalData.Projections;


namespace NorthWindCoreLibrary.Classes
{
    public class ProductsOperations
    {
        /// <summary>
        /// Example for retrieving products via nested projection
        ///
        /// Query <see cref="Products"/> with a join on <see cref="Suppliers"/>
        /// 
        /// </summary>
        /// <returns>Task&lt;List of <see cref="Product"/> which is a projection</returns>
        public static async Task<List<Product>> GetProductsWithProjectionAsync()
        {
            var productList = new List<Product>();

            await Task.Run(async () =>
            {
                await using var context = new NorthContext();

                productList = await context.Products
                    .Include(product => product.Supplier)
                    .Select(Product.Projection)
                    .ToListAsync();

            });

            return productList;
        }
    }
}

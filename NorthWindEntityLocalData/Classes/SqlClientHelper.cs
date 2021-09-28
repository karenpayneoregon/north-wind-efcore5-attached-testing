using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NorthWindEntityLocalData.Classes
{
    public class SqlClientHelper
    {
        protected static string ConnectionString()
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            return configuration.GetConnectionString("DefaultConnection");

        }
    }
}

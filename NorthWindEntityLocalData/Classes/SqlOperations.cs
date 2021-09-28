using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NorthWindEntityLocalData.Classes
{
    public class SqlOperations : SqlClientHelper
    {
        private static readonly string _connectionString = ConnectionString();

        public static async Task<(Exception, bool, DataTable)> ReadCustomersTask(CancellationToken cancellationToken = default)
        {
            (Exception, bool, DataTable Table) result = (null, true, new DataTable());

            return await Task.Run(async () =>
            {

                await using var cn = new SqlConnection(_connectionString);
                await using var cmd = new SqlCommand { Connection = cn, CommandText = SelectStatement };

                try
                {
                    await cn.OpenAsync(cancellationToken);
                    var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                    result.Table.Load(reader);

                }
                catch (TaskCanceledException tce)
                {
                    result = (tce, false, null);

                }
                catch (Exception exception)
                {
                    result = (exception, false, null);
                }

                return result;

            }, cancellationToken);
        }

        public static string SelectStatement 
            => @"
SELECT Cust.CustomerIdentifier, 
       Cust.CompanyName, 
       Cust.ContactId, 
       CT.ContactTitle, 
       Con.FirstName, 
       Con.LastName, 
       Cust.CountryIdentifier, 
       C.Name, 
(
    SELECT TOP (1) PhoneNumber
    FROM ContactDevices AS c
    WHERE Con.ContactId IS NOT NULL
          AND Con.ContactId = ContactId
          AND PhoneTypeIdentifier = 3
) AS Phone, 
       Cust.ModifiedDate
FROM Customers AS Cust
     LEFT OUTER JOIN ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier
     LEFT OUTER JOIN Contacts AS Con ON Cust.ContactId = Con.ContactId
     LEFT OUTER JOIN Countries AS C ON Cust.CountryIdentifier = C.CountryIdentifier;
";
    }

    
}

﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace NorthWindEntityLocalData.Data.Configurations
{
    public partial class Northwind2020ContextProcedures
    {
        private readonly NorthContext _context;

        public Northwind2020ContextProcedures(NorthContext context)
        {
            _context = context;
        }

        public async Task<int> uspInsertCategory(string CategoryName, string Description, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null)
        {
            var parameterCategoryName = new SqlParameter
            {
                ParameterName = "CategoryName",
                Size = 30,
                Value = CategoryName ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterDescription = new SqlParameter
            {
                ParameterName = "Description",
                Value = Description ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NText,
            };

            var parameterIdentity = new SqlParameter
            {
                ParameterName = "Identity",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[uspInsertCategory] @CategoryName, @Description, @Identity OUTPUT", parameterCategoryName, parameterDescription, parameterIdentity, parameterreturnValue);

            Identity.SetValue(parameterIdentity.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}

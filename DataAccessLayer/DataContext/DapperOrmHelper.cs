using Dapper;  // Ensure Dapper is referenced for extension methods
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class DapperOrmHelper : IDapperOrmHelper
    {
        private readonly IConfiguration _configuration;

        //-- Dapper Settings
        public string ConnectionString { get; set; }
        public string ProviderName { get; }

        //-- Constructor of the class
        public DapperOrmHelper(IConfiguration configuration)
        {
            _configuration = configuration;

            //-- Dapper Setting
            ConnectionString = _configuration.GetConnectionString("DBConnection");
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new InvalidOperationException("Connection string 'DBConnection' is not configured.");
            }
            ProviderName = "System.Data.SqlClient";
        }

        //-- Dapper Connection string     
        public IDbConnection GetDapperContextHelper()
        {
            // Ensure that SqlConnection is being created with the valid connection string
            return new SqlConnection(ConnectionString);
        }

        // Add QueryAsync method to run queries asynchronously
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = GetDapperContextHelper())
            {
                // Open the connection asynchronously before running the query
                await connection.OpenAsync();

                // Execute the query asynchronously using Dapper
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }
    }
}

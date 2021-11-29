using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace vagtplanen.Server.Services
{
    public class MethodService
    {
        private readonly string _connectionString;
        public MethodService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgres");
        }

        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public async Task<int> CheckLogin(string un, string pw)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT check_login(@username, @password)";
                var values = new { username = un, password = pw };
                var result = await conn.QueryFirstOrDefaultAsync<int>(query, values);
                return result;
            }
        }
    }
}

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
    public class CoordinatorService
    {
        private readonly string _connectionString;
        public CoordinatorService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgres");
        }

        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<Coordinator>> Get()
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = "SELECT * FROM coordinator;";
                var result = await conn.QueryAsync<Coordinator>(query);
                return result.ToList();
            }
        }

        public async Task<Coordinator> Get(string un)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM coordinator WHERE username = @username";
                var result = await conn.QueryFirstOrDefaultAsync<Coordinator>(query, new { username = un });
                return result;
            }
        }

        public Coordinator CreateCoordinator(Coordinator obj)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL add_coordinator(@first_name, @last_name, @mobile, @username, @password)";
                var values = new
                {
                    first_name = obj.first_name,
                    last_name = obj.last_name,
                    mobil = obj.mobile,
                    username = obj.username,
                    password = obj.password
                };

                conn.ExecuteAsync(query, values);
                return obj;
            }
        }
    }
}

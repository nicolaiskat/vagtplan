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

        public async Task UseCoupon(int vol, int coup)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT use_coupon(@volunteer, @coupon)";
                var values = new { volunteer = vol, coupon = coup };
                await conn.ExecuteAsync(query, values);
            }
        }

        public async Task BuyCoupon(int vol, int coup)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT buy_coupon(@volunteer, @coupon)";
                var values = new { volunteer = vol, coupon = coup };
                await conn.ExecuteAsync(query, values);
            }
        }

        public async Task DeassignShift(int vol, int shi)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT deassign_shift(@volunteer, @shift)";
                var values = new { volunteer = vol, shift = shi };
                await conn.ExecuteAsync(query, values);
            }
        }

        public async Task AssignShift(int vol, int shi)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT assign_shift(@volunteer, @shift)";
                var values = new { volunteer = vol, shift = shi };
                await conn.ExecuteAsync(query, values);
            }
        }
    }
}

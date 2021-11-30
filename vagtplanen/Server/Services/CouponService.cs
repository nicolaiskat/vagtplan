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
    public class CouponService
    {
        private readonly string _connectionString;
        public CouponService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgres");
        }

        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<Coupon>> Get()
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = "SELECT * FROM all_coupons;";
                var result = await conn.QueryAsync<Coupon>(query);
                return result.ToList();
            }
        }

        public async Task<Coupon> Get(int id)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM coupon WHERE coupon_id = '{0}'";
                var result = await conn.QueryFirstOrDefaultAsync<Coupon>(query, id);
                return result;
            }
        }

        public Coupon CreateCoupon(Coupon obj)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL add_coupon(@description, @price)";
                var values = new
                {
                    description = obj.description,
                    price = obj.price
                };

                conn.ExecuteAsync(query, values);
                return obj;
            }
        }
    }
}

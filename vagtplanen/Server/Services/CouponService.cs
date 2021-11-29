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
                var query = "SELECT * FROM coupon;";
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

        //public async Task<Coupon> Create(Coupon obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var insertSQL = string.Format(
        //            @"CALL addcoupon(first_name, last_name, mobile, username, password)
        //                VALUES('{0}', '{1}', '{2}','{3}', '{4}');",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password);

        //        var res = conn.Execute(insertSQL);
        //        return obj;
        //    }
        //}

        //public async Task<Coupon> Update(int id, Coupon obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var query = string.Format(@"UPDATE public.coupon  SET email='{0}'  WHERE id={1};", obj, id);
        //        @"UPDATE public.coupon SET first_name='{0}', last_name, mobile, username, password, access WHERE coupon_id={6};",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password, obj.access, obj.coupon_id);
        //        conn.Execute(query);

        //        return obj;
        //    }
        //}

        //public async Task<Coupon> Update(Coupon coor)
        //{
        //    using (var conn = OpenConnection(_connStr))
        //    {
        //        var updateSQL = string.Format(@"UPDATE public.customer  SET email='{0}'  WHERE id={1};", "catcher_hwq@163.com", GetMaxId());
        //        var res = conn.Execute(updateSQL);
        //        Console.WriteLine(res > 0 ? "update successfully!" : "update failure");
        //        PrintData();
        //    }
        //}




        //public async Task Delete(int id)
        //{
        //    using (var conn = OpenConnection(_connStr))
        //    {
        //        var deleteSQL = string.Format(@"DELETE FROM public.customer WHERE id={0};", GetMaxId());
        //        var res = conn.Execute(deleteSQL);
        //        Console.WriteLine(res > 0 ? "delete successfully!" : "delete failure");
        //        PrintData();
        //    }
        //}



    }
}

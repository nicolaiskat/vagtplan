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

        //public async Task<Coordinator> Update(int id, Coordinator obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var query = string.Format(@"UPDATE public.coordinator  SET email='{0}'  WHERE id={1};", obj, id);
        //        @"UPDATE public.coordinator SET first_name='{0}', last_name, mobile, username, password, access WHERE coordinator_id={6};",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password, obj.access, obj.coordinator_id);
        //        conn.Execute(query);

        //        return obj;
        //    }
        //}

        //public async Task<Coordinator> Update(Coordinator coor)
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

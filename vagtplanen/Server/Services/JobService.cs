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
    public class JobService
    {
        private readonly string _connectionString;
        public JobService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgres");
        }

        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<Job>> Get()
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM all_jobs";

                var lookup = new Dictionary<int, Job>();
                var result = await conn.QueryAsync<Job, Shift, Job>(query, (j, s) => {
                    Job job;
                    if (!lookup.TryGetValue(j.job_id, out job))
                        lookup.Add(j.job_id, job = j);
                    job.shifts.Add(s);
                    return job;
                }, splitOn: "job_id, shift_id");
                var resultList = lookup.Values;
                return resultList;
            }
        }

        public async Task<Job> Get(int id)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM job WHERE job_id = '{0}'";
                var result = await conn.QueryFirstOrDefaultAsync<Job>(query, id);
                return result;
            }
        }

        //public async Task<Job> Create(Job obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var insertSQL = string.Format(
        //            @"CALL addjob(first_name, last_name, mobile, username, password)
        //                VALUES('{0}', '{1}', '{2}','{3}', '{4}');",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password);

        //        var res = conn.Execute(insertSQL);
        //        return obj;
        //    }
        //}

        //public async Task<Job> Update(int id, Job obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var query = string.Format(@"UPDATE public.job  SET email='{0}'  WHERE id={1};", obj, id);
        //        @"UPDATE public.job SET first_name='{0}', last_name, mobile, username, password, access WHERE job_id={6};",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password, obj.access, obj.job_id);
        //        conn.Execute(query);

        //        return obj;
        //    }
        //}

        //public async Task<Job> Update(Job coor)
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

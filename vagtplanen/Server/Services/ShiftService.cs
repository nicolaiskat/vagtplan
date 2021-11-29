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
    public class ShiftService
    {
        private readonly string _connectionString;
        public ShiftService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgres");
        }

        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<Shift>> Get()
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM all_shifts";

                var lookup = new Dictionary<int, Shift>();
                var result = await conn.QueryAsync<Shift, Job, Volunteer, Shift>(query, (s, j, v) => {
                    Shift shift;
                    if (!lookup.TryGetValue(s.shift_id, out shift))
                        lookup.Add(s.shift_id, shift = s);
                    shift.job = j; shift.volunteer = v;
                    return shift;
                }, splitOn: "shift_id, volunteer_id, job_id");
                var resultList = lookup.Values;
                return resultList;
            }
        }

        public async Task<Shift> Get(int id)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM shift WHERE shift_id = '{0}'";
                var result = await conn.QueryFirstOrDefaultAsync<Shift>(query, id);
                return result;
            }
        }

        public Shift CreateShift(Shift obj)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL add_shift(@start_t, @end_t, @descr, @jobid)";
                var values = new
                {
                    start_t = obj.start_time,
                    end_t = obj.end_time,
                    descr = obj.description,
                    jobid = obj.job.job_id
                };

                conn.ExecuteAsync(query, values);
                return obj;
            }
        }

        //public async Task<Shift> Update(int id, Shift obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var query = string.Format(@"UPDATE public.shift  SET email='{0}'  WHERE id={1};", obj, id);
        //        @"UPDATE public.shift SET first_name='{0}', last_name, mobile, username, password, access WHERE shift_id={6};",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password, obj.access, obj.shift_id);
        //        conn.Execute(query);

        //        return obj;
        //    }
        //}

        //public async Task<Shift> Update(Shift coor)
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

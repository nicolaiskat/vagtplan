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

        public Job Create(Job obj)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL add_coupon(@area)";
                var values = new
                {
                    area = obj.area
                };

                conn.ExecuteAsync(query, values);
                return obj;
            }
        }

        public int Delete(int id)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL delete_job(@_id)";
                var values = new
                {
                    _id = id
                };

                conn.ExecuteAsync(query, values);
                return id;
            }
        }
    }
}

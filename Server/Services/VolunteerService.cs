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
    public class VolunteerService
    {
        private readonly string _connectionString;
        public VolunteerService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgres");
        }

        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<Volunteer>> Get()
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM all_volunteers";

                var volDictionary = new Dictionary<int, Volunteer>();


                var list = conn.Query<Volunteer, Shift, Coupon, Volunteer>(
                query,
                (v, s, c) =>
                {
                    Volunteer volunteer;
                    if (!volDictionary.TryGetValue(v.volunteer_id, out volunteer))
                    {
                        volunteer = v;
                        volunteer.shifts = new List<Shift>();
                        volunteer.coupons = new List<Coupon>();
                        volDictionary.Add(volunteer.volunteer_id, volunteer);
                    }

                    volunteer.shifts.Add(s);
                    volunteer.coupons.Add(c);
                    return volunteer;
                },
                splitOn: "volunteer_id, coupon_id, shift_id")
                .Distinct()
                .ToList();
                return list;
            }
        }

        public async Task<Volunteer> Get(string un)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"SELECT * FROM all_volunteers WHERE username = @username";

                var volDictionary = new Dictionary<int, Volunteer>();


                var list = conn.Query<Volunteer, Shift, Coupon, Volunteer>(
                query,
                (v, s, c) =>
                {
                    Volunteer volunteer;
                    if (!volDictionary.TryGetValue(v.volunteer_id, out volunteer))
                    {
                        volunteer = v;
                        volunteer.shifts = new List<Shift>();
                        volunteer.coupons = new List<Coupon>();
                        volDictionary.Add(volunteer.volunteer_id, volunteer);
                    }

                    volunteer.shifts.Add(s);
                    volunteer.coupons.Add(c);
                    return volunteer;
                },
                splitOn: "volunteer_id, coupon_id, shift_id", param: new { username = un });
                return list.First();
            }
        }

        //public Volunteer CreateVolunteer(Volunteer obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var insertSQL = string.Format(
        //            @"CALL add_volunteer(first_name, last_name, mobile, username, password)
        //                VALUES('{0}', '{1}', '{2}','{3}', '{4}');",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password);

        //        var res = conn.ExecuteAsync(insertSQL);
        //        return obj;
        //    }
        //}

        //public async Task<Volunteer> Update(int id, Volunteer obj)
        //{
        //    using (var conn = OpenConnection(_connectionString))
        //    {
        //        var query = string.Format(@"UPDATE public.volunteer  SET email='{0}'  WHERE id={1};", obj, id);
        //        @"UPDATE public.volunteer SET first_name='{0}', last_name, mobile, username, password, access WHERE volunteer_id={6};",
        //                obj.first_name, obj.last_name, obj.mobile, obj.username, obj.password, obj.access, obj.volunteer_id);
        //        conn.Execute(query);

        //        return obj;
        //    }
        //}

        //public async Task<Volunteer> Update(Volunteer coor)
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

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

        public IEnumerable<Volunteer> Get()
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
                splitOn: "volunteer_id, shift_id, coupon_id")
                .Distinct()
                .ToList();
                return list;
            }
        }

        public Volunteer Get(string un)
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
                splitOn: "volunteer_id, shift_id, coupon_id", param: new { username = un });
                return list.First();
            }
        }

        public Volunteer Create(Volunteer obj)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL add_volunteer(@first_name, @last_name, @mobile, @username, @password)";
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

        public Volunteer Update(Volunteer obj)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL edit_volunteer(@id, @first_name, @last_name, @mobil)";
                var values = new
                {
                    id = obj.volunteer_id,
                    first_name = obj.first_name,
                    last_name = obj.last_name,
                    mobil = obj.mobile
                };

                conn.ExecuteAsync(query, values);
                return obj;
            }
        }

        public int Delete(int id)
        {
            using (var conn = OpenConnection(_connectionString))
            {
                var query = @"CALL delete_volunteer(@_id)";
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

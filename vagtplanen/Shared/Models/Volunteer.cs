using System;
using System.Collections.Generic;

public class Volunteer : User  {
	public int volunteer_id { get; set; }
    public double hours {
        get
        {
            double sum = 0;
            foreach (Shift shift in shifts)
            {
                var hours = (shift.end_time - shift.start_time).TotalHours;
                sum += hours;
            }
            return sum;
        }
    }

    public double points
    {
        get
        {
            double sum = -6;
            foreach (Shift shift in shifts)
            {
                var hours = (shift.end_time - shift.start_time).TotalHours;
                sum += hours;
            }
            foreach (Coupon coupon in coupons)
            {
                sum -= coupon.price;
            }
            if (sum < 0)
                return 0;
            return sum;
        }
    }

    public List<Shift> shifts { get; set; }
	public List<Coupon> coupons { get; set; }
}

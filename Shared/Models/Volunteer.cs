using System;
using System.Collections.Generic;

public class Volunteer : User  {
	public int volunteer_id { get; set; }
    public int hours { get; set; }
	public int points { get; set; }

	public List<Shift> shifts { get; set; }

	public List<Coupon> coupons { get; set; }

}

using System;
using System.Collections.Generic;

public class Job {
	public int job_id { get; set; }
	public string area { get; set; }

	public List<Shift> shifts { get; set; }

}

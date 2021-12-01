using System;

public class Shift {
    public int shift_id { get; set; }
    public DateTime start_time { get; set; }
    public DateTime end_time { get; set; }
    public string description { get; set; }
    public bool taken { get; set; }

	public Job job { get; set; }
    public Volunteer volunteer { get; set; }

    public bool getTaken()
    {
		return taken;
    }
}

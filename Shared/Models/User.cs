using System;
using System.ComponentModel.DataAnnotations;

public class User {

	public string first_name { get; set; }
	public string last_name { get; set; }
	public int mobile { get; set; }
	public string username { get; set; }
	private string password { get; set; }
	public int access { get; set; }

}

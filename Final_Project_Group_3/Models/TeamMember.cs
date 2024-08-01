using System.ComponentModel.DataAnnotations;

namespace Final_Project_Group_3.Models;

public class TeamMember
{
	[Key] public int TeamMemberId { get; set; }
	public string FullName { get; set; }

	/*Syntax for initializing DateTime objects is 
	 DateTime dateTime = new (int, int, int);
	*/
	public DateTime dateTime { get; set; } 

	public string CollegeProgram { get; set; }
	public int YearInProgram { get; set; }
} 
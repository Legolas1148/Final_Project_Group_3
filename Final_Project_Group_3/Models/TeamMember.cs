using System.ComponentModel.DataAnnotations;

namespace Final_Project_Group_3.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberId { get; set; }
        public string? FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string? CollegeProgram { get; set; }
        public string? YearInProgram { get; set; }
    }
}


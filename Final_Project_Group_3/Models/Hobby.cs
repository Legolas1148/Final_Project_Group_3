using System.ComponentModel.DataAnnotations;

namespace Final_Project_Group_3.Models
{
    public class Hobby
    {
        [Key] 
        public int TeamMemberId { get; set; }
        
        public string? FullName { get; set; }
        
        public string? HobbyName { get; set; }
        
        public string? Description { get; set; }
        
        public int YearsPracticed { get; set; }
    }
}

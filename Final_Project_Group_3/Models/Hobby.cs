using System.ComponentModel.DataAnnotations;

namespace Final_Project_Group_3.Models
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string HobbyName { get; set; }

        public string? Description { get; set; }
        
        public string SkillLevel { get; set; }
       
        public string Category { get; set; }
    }
}

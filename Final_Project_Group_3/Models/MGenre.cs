using System.ComponentModel.DataAnnotations;

namespace Final_Project_Group_3.Models;

public class MGenre
{
    [Key] public int TeamMemberId { get; set; }
    public string FullName { get; set; }
    public string MusicGenre { get; set; }
}
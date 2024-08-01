using Microsoft.EntityFrameworkCore;

namespace Final_Project_Group_3.Models
{
    public class TeamProjectContext : DbContext
    {
        public TeamProjectContext(DbContextOptions<TeamProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Final_Project_Group_3.Models.TeamMember> TeamMembers{ get; set; }
        public DbSet<Final_Project_Group_3.Models.Hobby> Hobbies{ get; set; }
        public DbSet<Final_Project_Group_3.Models.MGenre> MusicGenre{ get; set; }
        public DbSet<Final_Project_Group_3.Models.Foods> FavoriteFoods{ get; set; }
    } 
}
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Group_3.Data
{
    public class TeamProjectContext : DbContext
    {
        public TeamProjectContext(DbContextOptions<TeamProjectContext> options)
            : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers{ get; set; }
        public DbSet<Hobby> Hobbies{ get; set; }
        public DbSet<MGenre> MusicGenre{ get; set; }
        public DbSet<Foods> FavoriteFoods{ get; set; }
    } 
}
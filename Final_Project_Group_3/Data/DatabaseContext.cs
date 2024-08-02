using Microsoft.EntityFrameworkCore;

namespace Final_Project_Group_3.Data
{
    public class TeamProjectContext : DbContext
    {
        public TeamProjectContext(DbContextOptions<TeamProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Models.TeamMember> TeamMembers { get; set; }
        public DbSet<Models.Hobby> Hobbies { get; set; }
        public DbSet<Models.MGenre> MusicGenre { get; set; }
        public DbSet<Models.Foods> FavoriteFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TeamMember>().ToTable("Team Member");
            modelBuilder.Entity<Models.Hobby>().ToTable("Hobbies");
            modelBuilder.Entity<Models.MGenre>().ToTable("Music Genre");
            modelBuilder.Entity<Models.Foods>().ToTable("Favorite Foods");
        }
    } 
}
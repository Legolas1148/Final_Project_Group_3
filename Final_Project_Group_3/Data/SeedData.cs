using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Final_Project_Group_3.Models;

namespace Final_Project_Group_3.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new TeamProjectContext(serviceProvider.GetRequiredService<DbContextOptions<TeamProjectContext>>()))
            {
                if(context.TeamMembers.Any())
                {
                    return;
                }

                context.TeamMembers.AddRange(
                    new TeamMember
                    {
                        FullName = "Niteesh Rawal",
                        Birthdate = new DateTime(2003, 4, 19),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Sophomore"
                    }
                );

                context.Hobbies.AddRange(
                    new Hobby
                    {
                        FullName = "Niteesh Rawal",
                        HobbyName = "Playing Video Games",
                        Description = "I like to play video games in my free time.",
                        YearsPracticed = 15,
                        Category = "Indoor",
                        TeamMemberId = 1
                    }
                );

                context.MusicGenres.AddRange(
                    new MGenre
                    {
                        FullName = "Niteesh Rawal",
                        MusicGenre= "Classical",
                        GenreDescription = "Classical music is a genre of music that is typically composed in a more traditional style.",
                        Popularity = 5,
                        TeamMemberId = 1
                    }
                );

                context.FavoriteFoods.AddRange(
                    new Foods
                    {
                        TeamMemberId = 1,
                        FullName = "Niteesh Rawal",
                        FavoriteFoodName = "Mac and Cheese",
                        Type = "Fast Food",
                        Calories = 300
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

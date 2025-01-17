﻿using Microsoft.Extensions.DependencyInjection;
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
                    ,new TeamMember
                    {
                        FullName = "Grant Perry",
                        Birthdate = new DateTime(2003, 5, 8),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Sophomore"
                    },
                    new TeamMember
                    {
                        FullName = "Taka Kiuchi",
                        Birthdate = new DateTime(2003, 7, 29),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Pre-Junior"
                    },
                    new TeamMember
                    {
                        FullName = "Kshitij Maurya",
                        Birthdate = new DateTime(1999, 1, 1),
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
                        Category = "Indoor"
                    },
                    new Hobby
                    {
                        FullName = "Grant Perry",
                        HobbyName = "Watching Movies",
                        Description = "I like to watch movies in my free time.",
                        YearsPracticed = 10,
                        Category = "Indoor"
                    },
                    new Hobby
                    {
                        FullName = "Taka Kiuchi",
                        HobbyName = "Cooking",
                        Description = "I like to cook in my free time",
                        YearsPracticed = 5,
                        Category = "Indoor"
                    },
                    new Hobby
                    {
                        FullName = "Kshitij Maurya",
                        HobbyName = "Playing Cricket",
                        Description = "I like to play cricket in my free time.",
                        YearsPracticed = 10,
                        Category = "Outdoor"
                    }
                );

                context.MusicGenres.AddRange(
                    new MGenre
                    {
                        FullName = "Niteesh Rawal",
                        MusicGenre= "Classical",
                        GenreDescription = "Classical music is a genre of music that is typically composed in a more traditional style.",
                        Popularity = 5
                    },
                    new MGenre
                    {
                        FullName = "Grant Perry",
                        MusicGenre = "Rock",
                        GenreDescription = "Rock music is a genre of music that is typically composed with electric guitars and drums.",
                        Popularity = 5
                    },
                    new MGenre
                    {
                        FullName = "Taka Kiuchi",
                        MusicGenre = "Jazz",
                        GenreDescription = "Jazz music is a genre of music that is typically composed with saxophones and trumpets.",
                        Popularity = 5
                    },
                    new MGenre
                    {
                        FullName = "Kshitij Maurya",
                        MusicGenre = "Pop",
                        GenreDescription = "Pop music is a genre of music that is typically composed with catchy tunes and lyrics.",
                        Popularity = 5
                    }
                );

                context.FavoriteFoods.AddRange(
                    new Foods
                    {
                        FullName = "Niteesh Rawal",
                        FavoriteFoodName = "Mac and Cheese",
                        Type = "Fast Food",
                        Calories = 300
                    },
                    new Foods
                    {
                        FullName = "Grant Perry",
                        FavoriteFoodName = "Pancakes",
                        Type = "Fast Food",
                        Calories = 300
                    },
                    new Foods
                    {
                        FullName = "Taka Kiuchi",
                        FavoriteFoodName = "Burrito",
                        Type = "Fast Food",
                        Calories = 300
                    },
                    new Foods
                    { 
                        FullName = "Kshitij Maurya",
                        FavoriteFoodName = "Taco",
                        Type = "Fast Food",
                        Calories = 300
                    }   
                );

                context.SaveChanges();
            }
        }
    }
}
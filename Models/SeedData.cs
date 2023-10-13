using Microsoft.EntityFrameworkCore;
using csci340lab8.Data;

namespace csci340lab8.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MonsterContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MonsterContext>>()))
        {
            if (context == null || context.Monster == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Monster.Any())
            {
                return;   // DB has been seeded
            }

            context.Monster.AddRange(
                new Monster
                {
                    Name = "Skeleton",
                    Type = "Undead",
                    Level = 5,
                },

                new Monster
                {
                    Name = "Ghost",
                    Type = "Spirit",
                    Level = 8,
                },

                new Monster
                {
                    Name = "Wolf",
                    Type = "Beast",
                    Level = 3,
                },

                new Monster
                {
                    Name = "Goblin",
                    Type = "Humanoid",
                    Level = 10,
                }
            );
            context.SaveChanges();
        }
    }
}
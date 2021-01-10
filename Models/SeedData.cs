using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentRegistration.Data;
using System.Linq;

namespace StudentRegistration.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentRegistrationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StudentRegistrationContext>>()))
            {
                // Look for any movies.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        Name = "Pop Andrei",
                        BornDate = DateTime.Parse("1989-2-12"),
                        Genre = "Male",
                        Class = 7M
                    },

                    new Student
                    {
                        Name = "Ion Ionescu ",
                        BornDate = DateTime.Parse("1984-3-13"),
                        Genre = "Male",
                        Class = 8M
                    },

                    new Student
                    {
                        Name = "Maria Ana",
                        BornDate = DateTime.Parse("1999-2-23"),
                        Genre = "Female",
                        Class = 9.99M
                    },

                    new Student
                    {
                        Name = "Aura Lina",
                        BornDate = DateTime.Parse("1999-4-15"),
                        Genre = "Female",
                        Class = 8M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

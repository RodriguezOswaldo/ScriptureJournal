using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournalContext>>()))
            {
                // Look for any Journals.
                if (context.Journal.Any())
                {
                    return;   // DB has been seeded
                }

                context.Journal.AddRange(
                    new Journal
                    {
                        Book = "When Harry Met Sally",
                        DateAdded = DateTime.Parse("1989-2-12"),
                        BookInScriptures = "Romantic Comedy",
                        Chapter = 1
                    },

                    new Journal
                    {
                        Book = "Ghostbusters ",
                        DateAdded = DateTime.Parse("1984-3-13"),
                        BookInScriptures = "Comedy",
                        Chapter = 3
                    },

                    new Journal
                    {
                        Book = "Ghostbusters 2",
                        DateAdded = DateTime.Parse("1986-2-23"),
                        BookInScriptures = "Comedy",
                        Chapter = 9
                    },

                    new Journal
                    {
                        Book = "Rio Bravo",
                        DateAdded = DateTime.Parse("1959-4-15"),
                        BookInScriptures = "Western",
                        Chapter = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

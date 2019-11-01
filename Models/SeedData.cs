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
                        Book = "Book of Mormon",
                        DateAdded = DateTime.Parse("1989-2-12"),
                        BookInScriptures = "Alma",
                        Chapter = 37,
                        Verse = 37
                    },

                    new Journal
                    {
                        Book = "New Testament",
                        DateAdded = DateTime.Parse("1984-3-13"),
                        BookInScriptures = "Matthew",
                        Chapter = 3,
                        Verse = 18
                    },

                    new Journal
                    {
                        Book = "Doctrine & Covenants",
                        DateAdded = DateTime.Parse("1986-2-23"),
                        BookInScriptures = "Section",
                        Chapter = 89
                    },

                    new Journal
                    {
                        Book = "Pearl of Great Price",
                        DateAdded = DateTime.Parse("1959-4-15"),
                        BookInScriptures = "Moses",
                        Chapter = 1,
                        Verse = 18
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

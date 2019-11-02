using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Models.ScriptureJournalContext _context;

        public IndexModel(ScriptureJournal.Models.ScriptureJournalContext context)
        {
            _context = context;
        }
       

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Book { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Comments { get; set; }

        public IList<Journal> Journal { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Journal
                orderby m.Book
                select m.Book;

            var books = from m in _context.Journal
                select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Comments))
            {
                books = books.Where(x => x.Book == Comments);
            }
            Book = new SelectList(await genreQuery.Distinct().ToListAsync());
            Journal = await books.ToListAsync();

//            var books = from m in _context.Journal
//                        select m;
//            if (!string.IsNullOrEmpty(SearchString))
//            {
//                books = books.Where(s => s.Book.Contains(SearchString));
//            }
//              The second "Journal" in this line was the problem 
//            Journal = await books.Journal.ToListAsync();
        }
    }
}

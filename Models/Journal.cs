using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureJournal.Models
{
    public class Journal
    {

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Display(Name = "Book In Scriptures")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string BookInScriptures { get; set; }

        public int Chapter { get; set; }

        public int Verse { get; set; }

        [StringLength(500, MinimumLength = 0)]
        [Required]
        public string Comments { get; set; }

        [Display(Name= "Entree Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}

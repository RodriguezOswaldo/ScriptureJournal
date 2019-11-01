using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureJournal.Models
{
    public class Journal
    {

        public int ID { get; set; }

        //[StringLength(60, MinimumLength = 1)]
        public string Book { get; set; }

        //[StringLength(60, MinimumLength = 1)]
        public string BookInScriptures { get; set; }

        //[Range(1, 100), DataType(DataType.Custom)]
        public int Chapter { get; set; }

        //[Range(1, 100), DataType(DataType.Custom)]
        public int Verse { get; set; }

       // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Comments { get; set; }
        [Display(Name= "Date Added")]

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}

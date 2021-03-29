using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMidterm.Models
{
    //Model to create our quote table
    public class QuoteResponse
    {
        [Key]
        [Required]
        public int QuoteID { get; set; }

        [Required]
        public string Quote { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Subject { get; set; }
        public string Citation { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMidterm.Models
{
    public class QuotesDBContext : DbContext
    {
        //inherit base options from the DbContext class
        public QuotesDBContext(DbContextOptions<QuotesDBContext> options) : base(options)
        {

        }

        //creating the table in the database storing QuoteResponse model objects
        public DbSet<QuoteResponse> Quotes { get; set; }
    }
}

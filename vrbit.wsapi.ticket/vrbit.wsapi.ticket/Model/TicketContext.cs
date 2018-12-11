using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vrbit.wsapi.ticket.Model
{
    public class TicketContext : DbContext
    {
        public TicketContext()
        {

        }

        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

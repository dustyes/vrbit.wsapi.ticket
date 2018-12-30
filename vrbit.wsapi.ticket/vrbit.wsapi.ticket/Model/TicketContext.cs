using Microsoft.EntityFrameworkCore;

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
        public DbSet<User> Users { get; set; }
    }
}

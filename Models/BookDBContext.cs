using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace address_bk.Models
{
    public class BookDBContext : IdentityDbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }
        public DbSet<BookContacts> Contacts { get; set; }
    }
}

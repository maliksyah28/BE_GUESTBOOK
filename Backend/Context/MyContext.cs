using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<GuestBookModel> Guest_Books { get; set; }
    }
}

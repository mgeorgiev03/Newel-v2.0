using Microsoft.EntityFrameworkCore;
using Newel.Server.Model;

namespace Newel.Server
{
    public class NewelDbContext : DbContext
    {
        public NewelDbContext(DbContextOptions options) : base(options) 
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}

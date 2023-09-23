﻿using Microsoft.EntityFrameworkCore;
using Newel.Server.Model;

namespace Newel.Server
{
    public class NewelDbContext : DbContext
    {
        readonly string connectionString = "Server = (localdb)\\mssqllocaldb; Database = NewelDbv2";

        public NewelDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using RocheChallenge.DTOs;

namespace RocheChallenge.DbContexts
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}

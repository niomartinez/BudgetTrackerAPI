using BudgetTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.API.DataAccess
{
    public class BudgetTrackerDbContext : DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Source> Sources { get; set; }
    }
}

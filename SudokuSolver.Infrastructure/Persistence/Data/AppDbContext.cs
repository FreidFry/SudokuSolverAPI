using Microsoft.EntityFrameworkCore;
using SudokuSolver.Infrastructure.Persistence.Models;

namespace SudokuSolver.Infrastructure.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public int TotalResolve { get; set; }
    
    public DbSet<GridTable> Table { get; set; }
}
using Microsoft.EntityFrameworkCore;
using TimetableManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.Data;

public class DataContext : DbContext
{ 
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<GoalEntity> Goals { get; set; }

    public DbSet<ImportantDateEntity> ImportantDates { get; set; }

    public DbSet<NoteEntity> Notes { get; set; }

    public DbSet<ReminderEntity> Reminders { get; set; }

    public DbSet<TaskEntity> Tasks { get; set; }
}

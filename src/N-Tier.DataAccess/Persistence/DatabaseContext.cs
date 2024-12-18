using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using N_Tier.Core.Common;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Identity;
using N_Tier.Shared.Services;

namespace N_Tier.DataAccess.Persistence;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    private readonly IClaimService _claimService;

    public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    public DbSet<TodoList> TodoLists { get; set; }

    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<AttendanceStatus> AttendanceStatus { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<EventParticipants> EventParticipants { get; set; }
    public DbSet<EventRoom> EventRoom { get; set; }
    public DbSet<Exam> Exam { get; set; }
    public DbSet<ExamBall> ExamBall { get; set; }
    public DbSet<ExamGroup> ExamGroup { get; set; }
    public DbSet<ExamGroupRoom> ExamGroupRoom { get; set; }
    public DbSet<Group> Group { get; set; }
    public DbSet<GroupRoom> GroupRoom { get; set; }
    public DbSet<Lesson> Lesson { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Specialist> Specialist { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<TotalNumberOfEventParticipants> TotalNumberOfEventParticipants { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

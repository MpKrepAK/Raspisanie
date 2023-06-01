using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;

namespace Raspisanie.Models.Database;

public class RaspisanieContext : DbContext
{
    public DbSet<Cabinet> Cabinets { get; set; }= null!;
    public DbSet<Date> Dates { get; set; }= null!;
    public DbSet<Day> Days { get; set; }= null!;
    public DbSet<DaySchedule> DaySchedules { get; set; }= null!;
    public DbSet<Group> Groups { get; set; }= null!;
    public DbSet<GroupSubjectTime> GroupSubjectTimes { get; set; }= null!;
    public DbSet<MainSchedule> MainSchedules { get; set; }= null!;
    public DbSet<ReplacementTeacher> ReplacementTeachers { get; set; }= null!;
    public DbSet<Subgroup> Subgroups { get; set; }= null!;
    public DbSet<Subject> Subjects { get; set; }= null!;
    public DbSet<Teacher> Teachers { get; set; }= null!;
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }= null!;
    public RaspisanieContext(DbContextOptions<RaspisanieContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReplacementTeacher>()
            .HasOne(u => u.DaySchedule)
            .WithOne(p => p.ReplacementTeacher)
            .HasForeignKey<ReplacementTeacher>(p => p.DayScheduleId);
    }
}
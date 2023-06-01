using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Implementations;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie;

public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContext<RaspisanieContext>(options =>
        {
            options.UseNpgsql(_configuration.GetConnectionString("Default"));
        });

        services.AddTransient<IRepository<Cabinet>, CabinetRepository>();
        services.AddTransient<IRepository<Date>, DateRepository>();
        services.AddTransient<IRepository<Day>, DayRepository>();
        services.AddTransient<IRepository<DaySchedule>, DayScheduleRepository>();
        services.AddTransient<IRepository<Group>, GroupRepository>();
        services.AddTransient<IRepository<GroupSubjectTime>, GroupSubjectTimeRepository>();
        services.AddTransient<IRepository<MainSchedule>, MainScheduleRepository>();
        services.AddTransient<IRepository<ReplacementTeacher>, ReplacementTeacherRepository>();
        services.AddTransient<IRepository<Subgroup>, SubgroupRepository>();
        services.AddTransient<IRepository<Subject>, SubjectRepository>();
        services.AddTransient<IRepository<Teacher>, TeacherRepository>();
        services.AddTransient<IRepository<TeacherSubject>, TeacherSubjectRepository>();
        
        
        
        services.AddControllers();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        
        app.UseRouting();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }


}
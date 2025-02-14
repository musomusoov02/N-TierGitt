﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using N_Tier.Application.Common.Email;
using N_Tier.Application.MappingProfiles;
using N_Tier.Application.Services;
using N_Tier.Application.Services.DevImpl;
using N_Tier.Application.Services.Impl;
using N_Tier.Shared.Services;
using N_Tier.Shared.Services.Impl;

namespace N_Tier.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        services.AddScoped<ITodoListService, TodoListService>();
        services.AddScoped<ITodoItemService, TodoItemService>();



        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IAttendanceStatusService, AttendanceStatusService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEventParticipantsService, EventParticipantsService>();

        services.AddScoped<IEventRoomService, EventRoomService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IExamBallService, ExamBallService>();
        services.AddScoped<IExamGroupRoomService, ExamGroupRoomService>();
        services.AddScoped<IExamGroupService, ExamGroupService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IGroupRoomService, GroupRoomService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<ISpecialistService, SpecialistService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();






        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<ITemplateService, TemplateService>();

        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}

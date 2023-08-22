using Mc2.CureCost.Core.DTOs;
using Mc2.CureCost.Domain.Commands;
using Mc2.CureCost.Domain.Events;
using Mc2.CureCost.Domain.Interfaces;
using Mc2.CureCost.Domain.Queries;
using Mc2.CureCost.Presentation.Infrastructure;
using Mc2.CureCost.Repository;
using Mc2.CureCost.Service.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Mc2.CureCost.Presentation.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Configure the DbContext.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });
            builder.Services.AddScoped<IRequestHandler<GetAllCustomersQuery, CustomerReadDTO[]>, GetAllCustomersQueryHandler>();

            builder.Services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();
            builder.Services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
            builder.Services.AddScoped<IEventRepository<IDomainEvent>, EventRepository>();

            builder.Services.AddScoped<ICustomerEventHandler, CustomerEventHandler>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommand))
                                            .RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommandHandler)));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
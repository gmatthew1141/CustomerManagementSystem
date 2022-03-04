using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using RacquetWebapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace RacquetWebapp {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            // Add in memory repository dependency
            services.AddScoped<ICustomerRepository, CustomerInMemoryRepository>();
            services.AddScoped<IBookingRepository, BookingInMemoryRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceInMemoryRepository>();
            services.AddScoped<IScheduleRepository, ScheduleInMemoryRepository>();

            // Add interfaces dependencies
            services.AddTransient<IViewCustomerUseCase, ViewCustomerUseCase>();
            services.AddTransient<IAddCustomerUseCase, AddCustomerUseCase>();
            services.AddTransient<IEditCustomerUseCase, EditCustomerUseCase>();
            services.AddTransient<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();
            services.AddTransient<IRemoveCustomerUseCase, RemoveCustomerUseCase>();
            services.AddTransient<IViewBookingsUseCase, ViewBookingsUseCase>();
            services.AddTransient<IGetTimestampUseCase, GetTimestampUseCase>();
            services.AddTransient<IAddBookingUseCase, AddBookingUseCase>();
            services.AddTransient<IEditBookingUseCase, EditBookingUseCase>();
            services.AddTransient<IGetBookingByIdUseCase, GetBookingByIdUseCase>();
            services.AddTransient<IRemoveBookingUseCase, RemoveBookingUseCase>();
            services.AddTransient<IGetBookingsByDateUseCase, GetBookingsByDateUseCase>();
            services.AddTransient<IGetAttendanceByDateUseCase, GetAttendanceByDateUseCase>();
            services.AddTransient<IGetScheduleUseCase, GetScheduleUseCase>();
            services.AddTransient<IGenerateScheduleByDateUseCase, GenerateScheduleByDateUseCase>();
            services.AddTransient<IUpdateAttendanceUseCase, UpdateAttendanceUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
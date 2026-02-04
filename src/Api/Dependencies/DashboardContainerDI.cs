using Application.Services.Dashboard;
using Application.Services.Dashboard.Features;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Api.Dependencies
{
    public class DashboardContainerDI
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<DashboardUseCases>();
            services.AddScoped<GetDashboardData>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
        }
    }
}

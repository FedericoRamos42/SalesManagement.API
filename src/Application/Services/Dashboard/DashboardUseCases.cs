using Application.Services.Dashboard.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dashboard
{
    public record DashboardUseCases(
        GetDashboardData Get
        );
    
}

﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using phemon.Application.message.HealthChecks;
using System.Reflection;


namespace phemon.Application.message
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register Application Health Checks
            services.AddHealthChecks()
                .AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

            //Register HealthCheckUI
            services.AddHealthChecksUI(options =>
            {
                options.AddHealthCheckEndpoint("Healthcheck API", "/healtcheck");
            })
            .AddInMemoryStorage();

            // Register MediatR Services
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

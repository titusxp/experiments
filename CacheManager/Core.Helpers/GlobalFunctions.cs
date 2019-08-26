using Database;
using Database.Dama.Test.Console;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using System;

namespace Core.Helpers
{
    public static class DependencyRegistry
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(ICachedReportsRepository), typeof(CachedReportsRepository), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IStudentsRepository), typeof(StudentsRepository), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IMongoDBClient<>), typeof(MongoDBClient<>), ServiceLifetime.Singleton));
        }
    }
}//

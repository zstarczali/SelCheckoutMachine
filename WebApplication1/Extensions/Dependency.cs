using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection

{
    public static class MyConfigServiceCollectionExtensions
        {
            public static IServiceCollection AddConfig(
                this IServiceCollection services, IConfiguration config)
            {


                return services;
            }
        }
    }


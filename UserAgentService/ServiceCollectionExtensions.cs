using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ng.Services
{
    /// <summary>
    /// Contains static methods to help with Dependancy Injection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the user agent service to the DI container
        /// </summary>
        /// <param name="serviceCollection">DI container</param>
        /// <returns>DI container</returns>
        public static IServiceCollection AddUserAgentService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IUserAgentService, UserAgentService>();
        }

        /// <summary>
        /// Adds the user agent service with options to the DI container
        /// </summary>
        /// <param name="serviceCollection">DI container</param>
        /// <param name="options">Options for UserAgentService</param>
        /// <returns>DI container</returns>
        public static IServiceCollection AddUserAgentService(this IServiceCollection serviceCollection, Action<UserAgentSettings> options)
        {
            serviceCollection.AddSingleton<IUserAgentService, UserAgentService>();
            serviceCollection.Configure(options);
            return serviceCollection;
        }
    }
}

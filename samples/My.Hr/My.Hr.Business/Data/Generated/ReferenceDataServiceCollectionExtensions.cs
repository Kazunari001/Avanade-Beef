/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using Microsoft.Extensions.DependencyInjection;

namespace My.Hr.Business.Data
{
    /// <summary>
    /// Provides the generated <b>Data</b>-layer services.
    /// </summary>
    public static class ReferenceDataServiceCollectionsExtension
    {
        /// <summary>
        /// Adds the generated <b>Data</b>-layer services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddGeneratedReferenceDataDataServices(this IServiceCollection services)
        {
            return services.AddScoped<IReferenceDataData, ReferenceDataData>();
        }
    }
}

#pragma warning restore
#nullable restore
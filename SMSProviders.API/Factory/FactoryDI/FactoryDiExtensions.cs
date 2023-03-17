using Microsoft.Extensions.DependencyInjection.Extensions;
using SMSProviders.API.Factory.FactoryOptions;
using SMSProviders.API.IService;

namespace SMSProviders.API.Factory.FactoryDI
{
    public static class FactoryDiExtensions
    {
        public static IServiceCollection RegisterTransientSpeaker<TImplementation>(this IServiceCollection services, string name)
            where TImplementation : class, ISMSServiceProvider
        {
            services.TryAddTransient<SMSFactory>();
            services.TryAddTransient<TImplementation>();
            services.Configure<SMSFactoryOptions>(options => options.Register<TImplementation>(name));
            return services;
        }
    }
}

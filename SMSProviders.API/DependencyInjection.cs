using SMSProviders.API.Factory.FactoryDI;
using SMSProviders.API.Helpers.Unit;
using SMSProviders.API.IService;
using SMSProviders.API.Mapper;
using SMSProviders.API.Service.SMSService;
using SMSProviders.API.Service.SMSServiceProvider;

namespace SMSProviders.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();

            services.AddTransient<IUnitOfWork, UnitOfWork>()
                    .AddTransient<ISMSService, SMSService>();

            services.RegisterTransientSpeaker<GeocellServiceProvider>("Geocell")
                .RegisterTransientSpeaker<MagtiServiceProvider>("Magti")
                .RegisterTransientSpeaker<TwilioServiceProvider>("Twilio");

            return services;
        }
    }
}

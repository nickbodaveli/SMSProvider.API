using Mapster;
using SMSProviders.API.Models;

namespace SMSProviders.API.Mapper
{
    public class ProviderMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Provider, ProviderDto>();
        }
    }
}

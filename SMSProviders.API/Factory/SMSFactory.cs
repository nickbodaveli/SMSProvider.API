using Microsoft.Extensions.Options;
using SMSProviders.API.Factory.FactoryOptions;
using SMSProviders.API.IService;

namespace SMSProviders.API.Factory
{
    public class SMSFactory 
    {
        private readonly IServiceProvider _provider;
        private readonly IDictionary<string, Type> _types;

        public SMSFactory(IServiceProvider provider, IOptions<SMSFactoryOptions> options)
        {
            _provider = provider;
            _types = options.Value.Types;
        }

        public ISMSServiceProvider Path(string name)
        {
            if (_types.TryGetValue(name, out var type))
            {
                return (ISMSServiceProvider)_provider.GetRequiredService(type);
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}

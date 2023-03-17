using SMSProviders.API.Enum;
using SMSProviders.API.Models;

namespace SMSProviders.API.IService
{
    public interface ISMSService 
    {
        public Task<bool> AddProvider(Provider provider);
        public Task<object> SendBySelect(ProviderSelectorEnum type, string content, int smsQuantity);
    }
}

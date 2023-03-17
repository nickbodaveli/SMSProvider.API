using SMSProviders.API.Enum;
using SMSProviders.API.Factory;
using SMSProviders.API.Helpers.Unit;
using SMSProviders.API.IService;
using SMSProviders.API.Models;

namespace SMSProviders.API.Service.SMSService
{
    public class SMSService : ISMSService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SMSFactory _smsFactory;

        public SMSService(SMSFactory smsFactory, IUnitOfWork unitOfWork)
        {
            _smsFactory = smsFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddProvider(Provider provider)
        {
            var getProvider = await _unitOfWork.Providers.Get(q => q.Name == provider.Name);

            if(getProvider == null) 
            {
                await _unitOfWork.Providers.Insert(provider);
                await _unitOfWork.Save();
                
                return true;
            }

            return false;
        }

        public async Task<object> SendBySelect(ProviderSelectorEnum type, string content, int smsQuantity)
        {
            var providers = await _unitOfWork.Providers.GetAll();

            if (providers != null)
            {
                switch (type)
                {
                    case ProviderSelectorEnum.Random:
                        var random = await SelectByRandom(providers, content, smsQuantity);
                        return random;
                    case ProviderSelectorEnum.Percent:
                        var percent = await SelectByPercent(providers, content, smsQuantity);
                        return percent;
                    default:
                        break;
                }
            }

            return null;
        }

        private async Task<string> SelectByRandom(IList<Provider> providers, string content, int smsQuantity)
        {
            Random rand = new Random();

            int providerIndex = rand.Next(0, providers.Count());

            var provider = _smsFactory.Path(providers[providerIndex].Name);

            var sendToProvider = await provider.SendSMS(content, Convert.ToInt32(smsQuantity));

            return sendToProvider;
        }

        private async Task<List<string>> SelectByPercent(IList<Provider> providers, string content, int smsQuantity)
        {
            List<string> providerSmsSendingList = new List<string>();

            double sumOfProviderPercents = 0;

            foreach (var item in providers)
            {
                sumOfProviderPercents += item.Percent;
            }

            double smsCountForOnePercent = smsQuantity / sumOfProviderPercents;

            foreach (var item in providers)
            {
                var provider = _smsFactory.Path(item.Name);
                var smsBasedOnPercentForProvider = smsCountForOnePercent * item.Percent;
                var rame = await provider.SendSMS(content, Convert.ToInt32(smsBasedOnPercentForProvider));
                providerSmsSendingList.Add(rame);
            }

            return providerSmsSendingList;
        }
    }
}

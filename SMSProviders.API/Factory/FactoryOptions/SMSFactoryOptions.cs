using SMSProviders.API.IService;

namespace SMSProviders.API.Factory.FactoryOptions
{
    public class SMSFactoryOptions
    {
        public IDictionary<string, Type> Types { get; } = new Dictionary<string, Type>();

        public void Register<T>(string name) where T : ISMSServiceProvider
        {
            Types.Add(name, typeof(T));
        }
    }
}

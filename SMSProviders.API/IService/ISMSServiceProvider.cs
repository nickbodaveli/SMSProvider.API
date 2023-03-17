namespace SMSProviders.API.IService
{
    public interface ISMSServiceProvider
    {
        public Task<string> SendSMS(string content, int smsBasedOnPercent);
    }
}

using SMSProviders.API.IService;

namespace SMSProviders.API.Service.SMSServiceProvider
{
    public class TwilioServiceProvider : ISMSServiceProvider
    {
        public async Task<string> SendSMS(string content, int smsBasedOnPercent)
        {
            return $"{smsBasedOnPercent} SMS Will be sent from Twilio";
        }
    }
}

using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SMSProviders.API.Enum;
using SMSProviders.API.IService;
using SMSProviders.API.Models;

namespace SMSProviders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;
        private readonly IMapper _mapper;

        public SMSController(ISMSService smsService, IMapper mapper)
        {
            _smsService = smsService;
            _mapper = mapper;
        }

        [HttpPost("AddProvider")]
        public async Task<bool> AddProvider(ProviderDto provider)
        {
            var map = _mapper.Map<Provider>(provider);
            if(await _smsService.AddProvider(map))
            {
                return true;
            }
            return false;
        }

        [HttpPost("SendSMS")]
        public async Task<object> SendSMS(ProviderSelectorEnum type, string content, int smsQuantity)
        {
            return await _smsService.SendBySelect(type, content, smsQuantity);
        }
    }
}

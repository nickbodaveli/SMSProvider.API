using SMSProviders.API.Helpers.Generic;
using SMSProviders.API.Models;

namespace SMSProviders.API.Helpers.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericService<Provider> Providers { get; }
        Task Save();
    }
}

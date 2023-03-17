using SMSProviders.API.Context;
using SMSProviders.API.Helpers.Generic;
using SMSProviders.API.Models;

namespace SMSProviders.API.Helpers.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericService<Provider> _providers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericService<Provider> Providers => _providers ??= new GenericService<Provider>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

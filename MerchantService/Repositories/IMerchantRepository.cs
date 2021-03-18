using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantService.Entities;

namespace MerchantService.Repositories
{
    public interface IMerchantRepository
    {
        Task CreateAsync(Merchant entity);
        Task<IReadOnlyCollection<Merchant>> GetAllAsync();
        Task<Merchant> GetAsync(Guid id);

    }
}

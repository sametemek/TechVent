using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantService.Entities;
using MongoDB.Driver;

namespace MerchantService.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private const string collectionName = "merchants"; 
        private readonly IMongoCollection<Merchant> dbCollection; 
        private readonly FilterDefinitionBuilder<Merchant> filterBuilder = Builders<Merchant>.Filter;

        public MerchantRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Merchant>(collectionName);
        }

        public async Task<IReadOnlyCollection<Merchant>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }
        public async Task<Merchant> GetAsync(Guid id)
        {
            FilterDefinition<Merchant> filter = filterBuilder.Eq(merchant => merchant.Id, id); return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Merchant merchant)
        {
            if (merchant == null)
            {
                throw new ArgumentNullException(nameof(merchant));
            } 
            await dbCollection.InsertOneAsync(merchant);
        }
    }
}

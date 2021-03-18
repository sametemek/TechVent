using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantService.Dtos;
using MerchantService.Entities;

namespace MerchantService
{
    public static class Extensions
    {
        public static MerchantDto AsDto(this Merchant item) { return new MerchantDto(item.Id, item.Name, item.Address); }
    }
}

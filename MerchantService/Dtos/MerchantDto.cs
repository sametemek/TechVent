using System;

namespace MerchantService.Dtos
{
    public record MerchantDto(
        Guid Id,
        string Name,
        string Address);
}
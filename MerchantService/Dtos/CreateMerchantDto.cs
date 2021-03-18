using System.ComponentModel.DataAnnotations;

namespace MerchantService.Dtos
{
    public record CreateMerchantDto(
    [Required] string Name,
    string Address);

}

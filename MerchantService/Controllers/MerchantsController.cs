using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantService.Dtos;
using MerchantService.Entities;
using MerchantService.Repositories;

namespace MerchantService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantRepository repository;

        public MerchantsController(IMerchantRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<MerchantDto>> GetAsync()
        {
            var itemEntities = await repository.GetAllAsync(); 
            var itemDtos = itemEntities.Select(entity => entity.AsDto()); 
            return itemDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MerchantDto>> GetByIdAsync(Guid id)
        {
            var item = await repository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            } 
            return item.AsDto();
        }


        [HttpPost]
        public async Task<ActionResult<MerchantDto>> PostAsync(CreateMerchantDto createItemDto)
        {
            var item = new Merchant()
            {
                Name = createItemDto.Name, 
                Address = createItemDto.Address
            };
            await repository.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }
    }
}

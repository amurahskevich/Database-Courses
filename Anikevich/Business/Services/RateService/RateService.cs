using Business.Dto;
using Business.Mappers.RateMappers;
using Data.Contracts.Entities;
using Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.RateService
{
    public class RateService : IRateService
    {
        private readonly ApplicationDbContext dbContext;

        public RateService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RateDto> Create(RateDto dto)
        {
            var rate = RateMapper.Map(dto);
            await dbContext.Rates.AddAsync(rate);
            await dbContext.SaveChangesAsync();

            return RateDtoMapper.Map(rate);
        }

        public async Task<IReadOnlyCollection<RateDto>> GetAll()
        {
            var rates = await dbContext.Rates
                .Include(x => x.Call)
                .Include(x => x.Sms)
                .Include(x => x.Internet)
                .Include(x => x.Roaming)
                .Include(x => x.HomeInternet)
                .ToListAsync();

            return rates
                .Select(RateDtoMapper.Map)
                .ToArray();
        }

        public async Task<RateDto> GetRateById(int id)
        {
            var rate = await this.GetById(id);

            return RateDtoMapper.Map(rate);
        }

        public async Task Remove(int id)
        {
            var rate = await dbContext.Rates.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.Remove(rate);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<RateDto> Update(RateDto dto)
        {
            var rate = await this.GetById(dto.Id);
            RateMapper.MapUpdate(rate, dto);
            await this.dbContext.SaveChangesAsync();

            return RateDtoMapper.Map(rate);
        }

        private async Task<Rate> GetById(int id)
        {
            return await dbContext.Rates
                .Include(x => x.Call)
                .Include(x => x.Sms)
                .Include(x => x.Internet)
                .Include(x => x.Roaming)
                .Include(x => x.HomeInternet)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}

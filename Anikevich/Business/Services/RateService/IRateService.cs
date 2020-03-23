using Business.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.RateService
{
    public interface IRateService
    {
        Task<IReadOnlyCollection<RateDto>> GetAll();

        Task<RateDto> GetRateById(int id);

        Task<RateDto> Create(RateDto dto);

        Task<RateDto> Update(RateDto dto);

        Task Remove(int id);
    }
}

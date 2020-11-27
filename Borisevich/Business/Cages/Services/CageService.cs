using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Cages.Mapping;
using Contracts.Cage;
using Domain;

namespace Business.Cages.Services
{
    public class CageService : ICageService
    {
        private readonly UnitOfWork unitOfWork;

        public CageService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<CageDto> Get(int id)
        {
            var cage = await this.unitOfWork.Cages.Get(id);

            return CageMapper.Map(cage);
        }

        public async Task<IReadOnlyCollection<CageDto>> GetList()
        {
            var cages = await this.unitOfWork.Cages.GetList();

            return cages.Select(CageMapper.Map).ToArray();
        }

        public async Task Create(CageDto entity)
        {
            var cage = CageMapper.Map(entity);

            await this.unitOfWork.Cages.Create(cage);
        }

        public async Task Update(CageDto entity)
        {
            var cage = await this.unitOfWork.Cages.Get(entity.Id);
            CageMapper.MapUpdate(cage, entity);

            await this.unitOfWork.Cages.Update(cage);
        }

        public async Task Delete(int id)
        {
            var cage = await this.unitOfWork.Cages.Get(id);

            await this.unitOfWork.Cages.Delete(cage);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Positions.Mapping;
using Contracts.Position;
using Domain;

namespace Business.Positions.Services
{
    public class PositionService : IPositionService
    {
        private readonly UnitOfWork unitOfWork;

        public PositionService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<PositionDto> Get(int id)
        {
            var position = await this.unitOfWork.Positions.Get(id);

            return PositionMapper.Map(position);
        }

        public async Task<IReadOnlyCollection<PositionDto>> GetList()
        {
            var positions = await this.unitOfWork.Positions.GetList();

            return positions.Select(PositionMapper.Map).ToArray();
        }

        public async Task Create(PositionDto entity)
        {
            var position = PositionMapper.Map(entity);

            await this.unitOfWork.Positions.Create(position);
        }

        public async Task Update(PositionDto entity)
        {
            var position = await this.unitOfWork.Positions.Get(entity.Id);
            PositionMapper.MapUpdate(position, entity);

            await this.unitOfWork.Positions.Update(position);
        }

        public async Task Delete(int id)
        {
            var position = await this.unitOfWork.Positions.Get(id);

            await this.unitOfWork.Positions.Delete(position);
        }
    }
}

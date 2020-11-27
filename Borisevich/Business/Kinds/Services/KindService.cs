using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Kinds.Mapping;
using Contracts.Kind;
using Domain;

namespace Business.Kinds.Services
{
    public class KindService : IKindService
    {
        private readonly UnitOfWork unitOfWork;

        public KindService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<KindDto> Get(int id)
        {
            var kind = await this.unitOfWork.Kinds.Get(id);

            return KindMapper.Map(kind);
        }

        public async Task<IReadOnlyCollection<KindDto>> GetList()
        {
            var kinds = await this.unitOfWork.Kinds.GetList();

            return kinds.Select(KindMapper.Map).ToArray();
        }

        public async Task Create(KindDto entity)
        {
            var kind = KindMapper.Map(entity);

            await this.unitOfWork.Kinds.Create(kind);
        }

        public async Task Update(KindDto entity)
        {
            var kind = await this.unitOfWork.Kinds.Get(entity.Id);
            KindMapper.MapUpdate(kind, entity);

            await this.unitOfWork.Kinds.Update(kind);
        }

        public async Task Delete(int id)
        {
            var kind = await this.unitOfWork.Kinds.Get(id);

            await this.unitOfWork.Kinds.Delete(kind);
        }
    }
}

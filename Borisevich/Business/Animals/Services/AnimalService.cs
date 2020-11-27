using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Animals.Mapping;
using Contracts.Animal;
using Domain;

namespace Business.Animals.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly UnitOfWork unitOfWork;

        public AnimalService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<AnimalDto> Get(int id)
        {
            var animal = await this.unitOfWork.Animals.Get(id);

            return AnimalMapper.Map(animal);
        }

        public async Task<IReadOnlyCollection<AnimalDto>> GetList()
        {
            var animals = await this.unitOfWork.Animals.GetList();

            return animals.Select(AnimalMapper.Map).ToArray();
        }

        public async Task Create(AnimalDto entity)
        {
            var animal = AnimalMapper.Map(entity);
            await this.unitOfWork.Animals.Create(animal);
        }

        public async Task Update(AnimalDto entity)
        {
            var animal = await this.unitOfWork.Animals.Get(entity.Id);
            AnimalMapper.MapUpdate(animal, entity);

            await this.unitOfWork.Animals.Update(animal);
        }

        public async Task Delete(int id)
        {
            var animal = await this.unitOfWork.Animals.Get(id);

            await this.unitOfWork.Animals.Delete(animal);
        }
    }
}

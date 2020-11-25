using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Animal;

namespace Business.Animals.Services
{
    public class AnimalService : IAnimalService
    {
        public Task<AnimalDto> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<AnimalDto>> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(AnimalDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(AnimalDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

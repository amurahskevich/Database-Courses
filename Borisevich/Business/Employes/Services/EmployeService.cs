using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Employes.Mapping;
using Business.Extensions;
using Contracts.Employe;
using Domain;

namespace Business.Employes.Services
{
    public class EmployeService : IEmployeService
    {
        private readonly UnitOfWork unitOfWork;

        public EmployeService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<EmployeDto> Get(int id)
        {
            var employe = await this.unitOfWork.Employes.Get(id);

            return EmployeMapper.Map(employe);
        }

        public async Task<IReadOnlyCollection<EmployeDto>> GetList()
        {
            var employe = await this.unitOfWork.Employes.GetList();

            return employe.Select(EmployeMapper.Map).ToArray();
        }

        public async Task Create(EmployeDto entity)
        {
            var employe = EmployeMapper.Map(entity);
            await this.unitOfWork.Employes.Create(employe);
            var animalEmployes = entity.Animals.OrEmpty()
                .Select(p => EmployeMapper.MapAnimalEmploye(p, employe.Id))
                .ToArray();
            await this.unitOfWork.AnimalEmployes.CreateRange(animalEmployes);
        }

        public async Task Update(EmployeDto entity)
        {
            var employe = await this.unitOfWork.Employes.Get(entity.Id);
            EmployeMapper.MapUpdate(employe, entity);
            await this.unitOfWork.AnimalEmployes.RemoveRange(employe.AnimalEmployes.ToArray());
            var animalEmployes = entity.Animals.OrEmpty()
                .Select(p => EmployeMapper.MapAnimalEmploye(p, employe.Id))
                .ToArray();
            await this.unitOfWork.AnimalEmployes.CreateRange(animalEmployes);
        }

        public async Task Delete(int id)
        {
            var employe = await this.unitOfWork.Employes.Get(id);

            await this.unitOfWork.Employes.Delete(employe);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class AnimalEmployeRepository
    {
        readonly ApplicationDbContext context;

        public AnimalEmployeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyCollection<AnimalEmploye>> GetByEmploye(int employeId)
        {
            return await this.context.AnimalEmployes.Where(p => p.EmployeId == employeId).ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<AnimalEmploye>> GetByAnimal(int animalId)
        {
            return await this.context.AnimalEmployes.Where(p => p.AnimalId == animalId).ToArrayAsync();
        }

        public async Task CreateRange(IReadOnlyCollection<AnimalEmploye> animalEmployes)
        {
            await this.context.AnimalEmployes.AddRangeAsync(animalEmployes);
            await this.context.SaveChangesAsync();
        }

        public async Task RemoveRange(IReadOnlyCollection<AnimalEmploye> animalEmployes)
        {
            this.context.AnimalEmployes.RemoveRange(animalEmployes);
            await this.context.SaveChangesAsync();
        }
    }
}

using System;
using System.Linq;
using Contracts.Employe;
using Domain.Entity;

namespace Business.Employes.Mapping
{
    public static class EmployeMapper
    {
        public static EmployeDto Map(Employe employe)
        {
            return new EmployeDto
            {
                Id = employe.Id,
                Name = employe.Name,
                Sex = (Sex)employe.Sex,
                Age = employe.Age,
                PositionId = employe.PositionId,
                PositionName = employe.Position.Name,
                Animals = employe.AnimalEmployes?
                    .Select(p => p.AnimalId)
                    .ToArray() ?? Array.Empty<int>(),
            };
        }

        public static Employe Map(EmployeDto employe)
        {
            return new Employe
            {
                Id = employe.Id,
                Name = employe.Name,
                Sex = (int)employe.Sex,
                Age = employe.Age,
                PositionId = employe.PositionId,
            };
        }

        public static void MapUpdate(Employe employe, EmployeDto employeDto)
        {
            employe.Name = employeDto.Name;
            employe.Sex = (int)employeDto.Sex;
            employe.Age = employe.Age;
            employe.PositionId = employeDto.PositionId;
        }

        public static AnimalEmploye MapAnimalEmploye(int animalId, int employeId)
        {
            return new AnimalEmploye
            {
                AnimalId = animalId,
                EmployeId = employeId,
            };
        }
    }
}

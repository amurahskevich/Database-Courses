using System;
using System.Linq;
using Contracts.Animal;
using Domain.Entity;

namespace Business.Animals.Mapping
{
    public static class AnimalMapper
    {
        public static AnimalDto Map(Animal animal)
        {
            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Sex = (Sex)animal.Sex,
                KindId = animal.KindId,
                KindName = animal.Kind.Name,
                CageId = animal.CageId,
                CageNumber = animal.Cage.Number,
                Employes = animal.AnimalEmployes?
                    .Select(p => p.EmployeId)
                    .ToArray() ?? Array.Empty<int>(),
            };
        }

        public static Animal Map(AnimalDto animal)
        {
            return new Animal
            {
                Id = animal.Id,
                Name = animal.Name,
                Sex = (int)animal.Sex,
                KindId = animal.KindId,
                CageId = animal.CageId,
            };
        }

        public static void MapUpdate(Animal animal, AnimalDto animalDto)
        {
            animal.Name = animalDto.Name;
            animal.Sex = (int)animalDto.Sex;
            animal.KindId = animalDto.KindId;
            animal.CageId = animalDto.CageId;
        }
    }
}

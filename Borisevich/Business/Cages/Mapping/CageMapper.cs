using Contracts.Cage;
using Domain.Entity;

namespace Business.Cages.Mapping
{
    public static class CageMapper
    {
        public static CageDto Map(Cage cage)
        {
            return new CageDto
            {
                Id = cage.Id,
                Number = cage.Number,
            };
        }

        public static Cage Map(CageDto cage)
        {
            return new Cage
            {
                Id = cage.Id,
                Number = cage.Number,
            };
        }

        public static void MapUpdate(Cage cage, CageDto cageDto)
        {
            cage.Number = cage.Number;
        }
    }
}

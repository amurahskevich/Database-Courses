using Contracts.Position;
using Domain.Entity;

namespace Business.Positions.Mapping
{
    public static class PositionMapper
    {
        public static PositionDto Map(Position position)
        {
            return new PositionDto
            {
                Id = position.Id,
                Name = position.Name,
            };
        }

        public static Position Map(PositionDto position)
        {
            return new Position
            {
                Id = position.Id,
                Name = position.Name,
            };
        }

        public static void MapUpdate(Position position, PositionDto positionDto)
        {
            position.Name = positionDto.Name;
        }
    }
}

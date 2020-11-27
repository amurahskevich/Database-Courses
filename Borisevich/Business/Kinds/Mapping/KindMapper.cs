using Contracts.Kind;
using Domain.Entity;

namespace Business.Kinds.Mapping
{
    public static class KindMapper
    {
        public static KindDto Map(Kind kind)
        {
            return new KindDto
            {
                Id = kind.Id,
                Name = kind.Name,
            };
        }

        public static Kind Map(KindDto kind)
        {
            return new Kind
            {
                Id = kind.Id,
                Name = kind.Name,
            };
        }

        public static void MapUpdate(Kind kind, KindDto kindDto)
        {
            kind.Name = kindDto.Name;
        }
    }
}

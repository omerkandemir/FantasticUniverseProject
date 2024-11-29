using NLayer.Core.Business.Abstract;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IAdventureService : IEntityServiceRepositoryAsync<Adventure>
{
    Task<IDataReturnType<ICollection<Adventure>>> GetAdventuresByPlanetId(int planetId);
}

using NLayer.Core.Business.Abstract;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IUniverseService : IEntityServiceRepositoryAsync<Universe>
{
    Task<IReturnType> CreateUniverseAsync(Universe universe);
    Task<IDataReturnType<ICollection<Universe>>> GetUserUniversesAsync(int userId);
}

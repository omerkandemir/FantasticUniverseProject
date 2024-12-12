using NLayer.Core.Business.Abstract;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IUnionService : IEntityServiceRepositoryAsync<Union, int>
{
}

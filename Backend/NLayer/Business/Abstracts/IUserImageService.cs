using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Concrete;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IUserImageService : IEntityServiceRepositoryAsync<UserImage>
{
    Task AddUserFirstImages();
    Task<IDataReturnType<List<UniverseImage>>> GetUsersImage();
}

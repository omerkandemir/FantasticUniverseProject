using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Concrete;

namespace NLayer.Business.Abstracts;

public interface IUserImageService : IEntityServiceRepository<UserImage>
{
    void AddUserFirstImages();
}

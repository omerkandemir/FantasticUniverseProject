using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Core.Entities.Concrete;
using NLayer.Core.Utilities.UserOperations;
using NLayer.DataAccess.Abstracts;

namespace NLayer.Business.Concretes.Managers;

public class UserImageManager : BaseManager<UserImage, IUserImageDal>, IUserImageService
{
    private readonly IUniverseImageDal _universeImageDal;
    public UserImageManager(IUserImageDal tdal, IUniverseImageDal userImageDal) : base(tdal)
    {
        _universeImageDal = userImageDal;
    }

    public void AddUserFirstImages()
    {
        int UserId = AccessUser.GetUserId();
        var universeImages = _universeImageDal.GetAll(x => x.Universe.Name == "Fantastic Universe", ui => ui.Include(ui => ui.Universe));

        foreach (var universeImage in universeImages)
        {
            var userImage = new UserImage
            {
                UniverseImageId = universeImage.Id,
                UserId = UserId
            };
            _tdal.Add(userImage);
        }
    }
}

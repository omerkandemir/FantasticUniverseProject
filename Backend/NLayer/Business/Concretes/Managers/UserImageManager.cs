using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Core.Entities.Concrete;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Core.Utilities.UserOperations;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

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

    public IDataReturnType<List<UniverseImage>> GetUsersImage()
    {
        try
        {
            int UserId = AccessUser.GetUserId();
            List<UserImage> userImages = _tdal.GetAll(x => x.UserId == UserId).ToList();
            List<UniverseImage> universeImages = new List<UniverseImage>();
            foreach (var item in userImages)
            {
                var universeImage = _universeImageDal.Get(x => x.Id == item.UniverseImageId);
                if (universeImage != null)
                {
                    universeImages.Add(universeImage);
                }
            }
            return new DataReturnType<List<UniverseImage>>(universeImages, GetDatasInfo.SuccessListData, CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<List<UniverseImage>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }
}

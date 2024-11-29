using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Core.Entities.Concrete;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Core.Utilities.UserOperations;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UserImageManager : BaseManagerAsync<UserImage, IUserImageDal>, IUserImageService
{
    private readonly IUniverseImageDal _universeImageDal;
    public UserImageManager(IUserImageDal tdal, IUniverseImageDal userImageDal) : base(tdal)
    {
        _universeImageDal = userImageDal;
    }

    public async Task AddUserFirstImages()
    {
        await ExecuteSafely(async () =>
        {
            int userId = AccessUser.GetUserId();
            var universeImages = await _universeImageDal.GetAllAsync(
                x => x.Universe.Name == "Fantastic Universe",
                ui => ui.Include(ui => ui.Universe)
            );

            var userImages = universeImages.Select(universeImage => new UserImage
            {
                UniverseImageId = universeImage.Id,
                UserId = userId
            });

            await _tdal.AddRangeAsync(userImages);
        }, CrudOperation.Add);
    }

    public async Task<IDataReturnType<ICollection<UniverseImage>>> GetUsersImage()
    {
        return await ExecuteQuerySafelyWithResult(
          async () =>
            {
                int userId = AccessUser.GetUserId();

                // Kullanıcıya ait UserImage veriler,
                var userImages = await _tdal.GetAllAsync(x => x.UserId == userId);

                // Kullanıcının sahip olduğu UniverseImageId'lerin listesi
                var universeImageIds = userImages.Select(ui => ui.UniverseImageId).ToList();

                // UniverseImage'de bu ID'lere göre sorgu yap
                var universeImages = await _universeImageDal.GetAllAsync(ui => universeImageIds.Contains(ui.Id));

                return universeImages;
            },
                 CrudOperation.List
            );
    }
}

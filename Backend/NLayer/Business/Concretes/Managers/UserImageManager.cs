﻿using Microsoft.EntityFrameworkCore;
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
        int UserId = AccessUser.GetUserId();
        var universeImages = await _universeImageDal.GetAllAsync(x => x.Universe.Name == "Fantastic Universe", ui => ui.Include(ui => ui.Universe));

        foreach (var universeImage in universeImages)
        {
            var userImage = new UserImage
            {
                UniverseImageId = universeImage.Id,
                UserId = UserId
            };
           await _tdal.AddAsync(userImage);
        }
    }

    public async Task<IDataReturnType<List<UniverseImage>>> GetUsersImage()
    {
        try
        {
            int UserId = AccessUser.GetUserId();
            List<UserImage> userImages = (await _tdal.GetAllAsync(x => x.UserId == UserId)).ToList();
            List<UniverseImage> universeImages = new List<UniverseImage>();
            foreach (var item in userImages)
            {
                var universeImage = await _universeImageDal.GetAsync(x => x.Id == item.UniverseImageId);
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

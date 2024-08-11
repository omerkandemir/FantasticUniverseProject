using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Concrete;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.UserImage;
using NLayer.Mapper.Responses.UniverseImage;
using NLayer.Mapper.Responses.UserImage;

namespace NLayer.Dto.Managers.Concrete;

public class UserImageDto : IUserImageDto
{
    private readonly IUserImageService _userImageService;
    private readonly IMapper _mapper;
    public UserImageDto(IUserImageService userImageService, IMapper mapper)
    {
        _userImageService = userImageService;
        _mapper = mapper;
    }
    public IResponse Add(CreateUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        var result = _userImageService.Add(userImage);
        var response = _mapper.Map<CreatedUserImageResponse>(userImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UserImage>(response, userImage);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IResponse Update(UpdateUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        var result = _userImageService.Update(userImage);
        var response = _mapper.Map<UpdatedUserImageResponse>(userImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UserImage>(response, userImage);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IResponse Delete(DeleteUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        var result = _userImageService.Delete(userImage);
        var response = _mapper.Map<DeletedUserImageResponse>(userImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UserImage>(response, userImage);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IGetResponse Get(object id)
    {
        var value = _userImageService.Get(id);
        var response = _mapper.Map<GetAllUserImageResponse>(value.Data);
        return response;
    }

    public List<GetAllUserImageResponse> GetAll()
    {
        var value = _userImageService.GetAll();
        var response = _mapper.Map<List<GetAllUserImageResponse>>(value.Data);
        return response;
    }
    public List<GetAllUniverseImageResponse> GetUsersImage()
    {
        var value = _userImageService.GetUsersImage();
        var response = _mapper.Map<List<GetAllUniverseImageResponse>>(value.Data);
        return response;
    }
    public void AddUserFirstImages()
    {
        _userImageService.AddUserFirstImages();
    }
}

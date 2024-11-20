using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Concrete;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.UserImage;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.UniverseImage;
using NLayer.Mapper.Responses.Concrete.UserImage;

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
    public async Task<IResponse> AddAsync(CreateUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        var result = await _userImageService.AddAsync(userImage);
        var response = _mapper.Map<CreatedUserImageResponse>(userImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UserImage>(userImage, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IResponse> UpdateAsync(UpdateUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        var result = await _userImageService.UpdateAsync(userImage);
        var response = _mapper.Map<UpdatedUserImageResponse>(userImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UserImage>(userImage, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IResponse> DeleteAsync(DeleteUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        var result = await _userImageService.DeleteAsync(userImage);
        var response = _mapper.Map<DeletedUserImageResponse>(userImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UserImage>(userImage, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _userImageService.GetAsync(id);
        var response = _mapper.Map<GetUserImageResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetUserImageResponse>> GetAllAsync()
    {
        var value = await _userImageService.GetAllAsync();
        var response = _mapper.Map<GetAllUserImageResponse>(value.Data);
        return response;
    }
    public async Task<IGetAllResponse<IGetUniverseImageResponse>> GetUsersImage()
    {
        var value = await _userImageService.GetUsersImage();
        var response = _mapper.Map<GetAllUniverseImageResponse>(value.Data);
        return response;
    }
    public async Task AddUserFirstImages()
    {
        await _userImageService.AddUserFirstImages();
    }
}

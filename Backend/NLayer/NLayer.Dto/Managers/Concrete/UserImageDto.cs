using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Concrete;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.UserImage;
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
    public IErrorResponse Add(CreateUserImageRequest request)
    {
        var value = _mapper.Map<UserImage>(request);
        var result = _userImageService.Add(value);
        var response = _mapper.Map<CreatedUserImageResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IErrorResponse Update(UpdateUserImageRequest request)
    {
        var value = _mapper.Map<UserImage>(request);
        var result = _userImageService.Update(value);
        var response = _mapper.Map<UpdatedUserImageResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IErrorResponse Delete(DeleteUserImageRequest request)
    {
        var value = _mapper.Map<UserImage>(request);
        var result = _userImageService.Delete(value);
        var response = _mapper.Map<DeletedUserImageResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
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

    public void AddUserFirstImages()
    {
        _userImageService.AddUserFirstImages();
    }
}

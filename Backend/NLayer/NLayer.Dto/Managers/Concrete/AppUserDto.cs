using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.AppUser;

namespace NLayer.Dto.Managers.Concrete;

public class AppUserDto : IAppUserDto
{
    private readonly IAppUserService _appUserService;
    private readonly IMapper _mapper;
    public AppUserDto(IAppUserService appUserService, IMapper mapper)
    {
        _appUserService = appUserService;
        _mapper = mapper;
    }
    public async Task<IErrorResponse> AddAsync(CreateAppUserRequest request)
    {
        AppUser value = _mapper.Map<AppUser>(request);
        value.ConfirmCode = SendMail.GenerateConfirmCode();
        var result = await _appUserService.AddAsync(value, request.Password);
        var response = _mapper.Map<CreatedAppUserResponse>(value);
        if (result.Success)
        {
            SendMail.SendConfirmCodeMail(value.ConfirmCode, value);
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {          
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    
    public async Task<IErrorResponse> UpdateAsync(UpdateAppUserRequest request)
    {
        AppUser value = _mapper.Map<AppUser>(request);
        var response = _mapper.Map<CreatedAppUserResponse>(value);
        var result = await _appUserService.UpdateAsync(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteAppUserRequest request)
    {
        throw new NotImplementedException();
    }

    public IGetResponse Get(object id)
    {
        throw new NotImplementedException();
    }

    public List<GetAllAppUserResponse> GetAll()
    {
        throw new NotImplementedException();
    }
    public IErrorResponse Add(CreateAppUserRequest request)
    {
        throw new NotImplementedException();
    }
    public IErrorResponse Update(UpdateAppUserRequest request)
    {
        throw new NotImplementedException();
    }
}
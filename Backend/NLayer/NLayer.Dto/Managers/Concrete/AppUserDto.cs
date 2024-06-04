using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    public AppUserDto(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public IErrorResponse Add(CreateAppUserRequest request)
    {
        throw new NotImplementedException();
    }
    public async Task<IErrorResponse> AddAsync(CreateAppUserRequest request)
    {
        Random random = new Random();
        int code = random.Next(100000, 1000000);
        var value = _mapper.Map<AppUser>(request);
        value.ConfirmCode = code;
        var result = await _userManager.CreateAsync(value, request.Password);
        var response = _mapper.Map<CreatedAppUserResponse>(value);
        if (result.Succeeded)
        {
           SendMail.SendConfirmCodeMail(code, value);

            return new SuccessResponse(response);
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description);
            var errorMessage = string.Join(", ", errors);
            return new ErrorResponse(errorMessage);
        }
    }

   

    public IErrorResponse Update(UpdateAppUserRequest request)
    {
        throw new NotImplementedException();
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
}
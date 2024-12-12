using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authorization;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppRole;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppRole;

namespace NLayer.Dto.Managers.Concrete;

public class AppRoleDto : IAppRoleDto
{
    private readonly IAppRoleService _appRoleService;
    private readonly IMapper _mapper;
    public AppRoleDto(IAppRoleService appRoleService, IMapper mapper)
    {
        _appRoleService = appRoleService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateAppRoleRequest request)
    {
        try
        {
            var appRole = _mapper.Map<AppRole>(request);
            var result = await _appRoleService.AddAsync(appRole);
            var response = _mapper.Map<CreatedAppRoleResponse>(appRole);
            if (result.Success)
                return ResponseFactory.CreateSuccessResponse<AppRole>(appRole, response);

            return ResponseFactory.CreateErrorResponse(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.CreateErrorResponse(ex.Message);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateAppRoleRequest request)
    {
        try
        {
            AppRole appRole = _mapper.Map<AppRole>(request);
            var response = _mapper.Map<UpdatedAppRoleResponse>(appRole);
            var result = await _appRoleService.UpdateAsync(appRole);
            if (result.Success)
                return ResponseFactory.CreateSuccessResponse<AppRole>(appRole, response);

            return ResponseFactory.CreateErrorResponse(result);

        }
        catch (Exception ex)
        {
            return ResponseFactory.CreateErrorResponse(ex.Message);
        }
    }

    public async Task<IResponse> DeleteAsync(DeleteConfirmationAppRoleRequest deleteAppRoleRequest)
    {
        try
        {
            var appRole = _mapper.Map<AppRole>(deleteAppRoleRequest);
            var result = await _appRoleService.DeleteAsync(appRole);
            if (result.Success)
                return ResponseFactory.CreateSuccessResponse(result);

            return ResponseFactory.CreateErrorResponse(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.CreateErrorResponse(ex.Message);
        }
    }

    public async Task<IGetAllResponse<IGetAppRoleResponse>> GetAllAsync()
    {
        var value = await _appRoleService.GetAllAsync();
        var response = _mapper.Map<GetAllAppRoleResponse>(value.Data);
        return response;
    }

    public async Task<IGetAppRoleResponse> GetAsync(object id)
    {
        var value = await _appRoleService.GetAsync(Convert.ToInt32(id));
        var response = _mapper.Map<GetAppRoleResponse>(value.Data);
        return response;
    }
}

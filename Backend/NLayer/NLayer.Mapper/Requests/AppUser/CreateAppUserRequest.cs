﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class CreateAppUserRequest : ICreateRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public int UniverseImageId { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

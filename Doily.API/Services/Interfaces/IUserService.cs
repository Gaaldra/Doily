using Doily.API.Common;
using Doily.Domain.DTOs.Requests;
using Doily.Domain.DTOs.Responses;

namespace Doily.API.Services.Interfaces;

public interface IUserService
{
    Task<ServiceResult<UserResponseDto>> RegisterUser(UserResgistrationDto request);
    Task<ServiceResult<UserResponseDto>> GetUserByID(int id);
}

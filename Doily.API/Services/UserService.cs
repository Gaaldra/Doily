using Doily.API.Common;
using Doily.API.Data;
using Doily.API.Services.Interfaces;
using Doily.Domain.DTOs.Requests;
using Doily.Domain.DTOs.Responses;
using Doily.Domain.Entities;

namespace Doily.API.Services;

public class UserService(DoilyContext context) : IUserService
{
    private DoilyContext _context = context;

    public async Task<ServiceResult<UserResponseDto>> RegisterUser(UserResgistrationDto request)
    {
        var newUser = new User(request.FirstName, request.LastName, request.Username, request.Password);
        try
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            UserResponseDto userResponse = new()
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Username = newUser.Username
            };
            return ServiceResult<UserResponseDto>.Success(userResponse);
        }
        catch (Exception)
        {
            return ServiceResult<UserResponseDto>.Fail("Usuario não pode ser inserido no banco de dados");
        }
    }
    public async Task<ServiceResult<UserResponseDto>> GetUserByID(int id)
    {
        User? user = await _context.Users.FindAsync(id);
        if (user is null) return ServiceResult<UserResponseDto>.Fail("Usuário não encontrado");
        UserResponseDto userResponse = new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username
        };
        return ServiceResult<UserResponseDto>.Success(userResponse);
    }
}

using AutoMapper;
using Doily.API.Common;
using Doily.API.Data;
using Doily.API.Services.Interfaces;
using Doily.Domain.DTOs.Requests;
using Doily.Domain.DTOs.Responses;
using Doily.Domain.Entities;

namespace Doily.API.Services;

public class UserService(DoilyContext context, IMapper mapper) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly DoilyContext _context = context;

    public async Task<ServiceResult<UserResponseDto>> RegisterUser(UserResgistrationDto request)
    {
        var newUser = new User(request.FirstName, request.LastName, request.Username, request.Password);
        try
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            var userResponse = _mapper.Map<UserResponseDto>(newUser);
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
        var userResponse = _mapper.Map<UserResponseDto>(user);
        return ServiceResult<UserResponseDto>.Success(userResponse);
    }
}

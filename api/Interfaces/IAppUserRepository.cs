using api.Dtos;
using api.Models;

namespace api.Interfaces;

public interface IAppUserRepository
{
    Task<AppUserDto?> Create(AppUser userInput);
}

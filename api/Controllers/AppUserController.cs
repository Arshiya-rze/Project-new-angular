using api.Dtos;
using api.Interfaces;
using api.Models;
using api.settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AppUserController : ControllerBase
{
    //MongoDb Settings Connect to Api
    private readonly IAppUserRepository _appUserRepository;

    //Dependency Injection
    public AppUserController(IAppUserRepository appUserRepository)
    {
      _appUserRepository = appUserRepository;
    }

    //HttpPost
    [HttpPost("register")]
    public async Task<ActionResult<AppUserDto>> Create(AppUser userInput)
    {
      //Check if password are match
      if (userInput.PassWord != userInput.ConfirmPassword)
        return BadRequest("passwords are not march!");

      AppUserDto? appUser = await _appUserRepository.Create(userInput);

      if (appUser is null)
        return BadRequest("user aleady exist");

        return appUser;
    }
}
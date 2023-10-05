using api.Dtos;
using api.Interfaces;
using api.Models;
using api.settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api.Repositories;

public class AppUserAccountRepository : IAppUserRepository
{
    //MongoDb Settings Connect to Api
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser> _collection;
    //Dependency Injection
    public AppUserAccountRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>(_collectionName);
    }

    [HttpPost("register")]
    public async Task<AppUserDto?> Create(AppUser userInput)
    {
        //Check if user already exist
        bool userExist = await _collection.Find<AppUser>(user => user.Email == userInput.Email.ToLower().Trim()).AnyAsync();

        if (userExist == true)
          return null;

        // Create object from input
        AppUser appUser = new AppUser(
            Id: null,
            Email: userInput.Email.ToLower().Trim(),
            PassWord: userInput.PassWord,
            ConfirmPassword: userInput.ConfirmPassword
        );

        //Return our object to database
        await _collection.InsertOneAsync(appUser);

        //Create new object for new type
        AppUserDto appUserDto = new AppUserDto(
          Id: appUser.Id!,
          Email: appUser.Email
        );
        
        //Return responce
        return appUserDto;
    }
        
}

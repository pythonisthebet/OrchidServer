using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrchidServer.DTO;

namespace OrchidServer.Models;

public partial class OrchidDbContext : DbContext
{
    public AppUser? GetUser(string email)
    {
        return this.AppUsers.Where(u => u.UserEmail == email)
                            .FirstOrDefault();
    }

    public AppUser? GetUserById(int id)
    {
        return this.AppUsers.Where(u => u.Id == id)
                            .FirstOrDefault();
    }

    public List<AppUser>? GetAllUsersC()
    {
        return this.AppUsers.ToList();
    }

    public List<Character>? GetAllCharacters(AppUser user)
    {
        return this.Characters.Where(u => u.User == user).ToList();
    }

    public List<Class>? GetAllClasses(Character character)
    {
        return this.Classes.Where(u => u.CharacterId == character.Id).ToList();
    }

    public Race? GetRace(Character character)
    {
        return this.Races.Where(u => u.Id == character.Id).FirstOrDefault();
    }

    public void RemoveAllClasses(Character character)
    {
        this.Classes.Where(u => u.CharacterId == character.Id).ExecuteDelete();
    }
}


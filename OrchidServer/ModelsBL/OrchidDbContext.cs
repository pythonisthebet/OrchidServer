using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrchidServer.DTO;

namespace OrchidServer.Models;

public partial class OrchidDbContext : DbContext
{
    //get the user tthat uses a given email
    public AppUser? GetUser(string email)
    {
        return this.AppUsers.Where(u => u.UserEmail == email)
                            .FirstOrDefault();
    }

    //get a user with a specific id
    public AppUser? GetUserById(int id)
    {
        return this.AppUsers.Where(u => u.Id == id)
                            .FirstOrDefault();
    }

    //get all app users
    public List<AppUser>? GetAllUsersC()
    {
        return this.AppUsers.ToList();
    }

    //get all characters that a user created
    public List<Character>? GetAllCharacters(AppUser user)
    {
        return this.Characters.Where(u => u.User == user).ToList();
    }

    //gets all filters
    public List<Filter>? GetAllFilters()
    {
        return this.Filters.ToList();
    }

    //get all characters that follow a list of filters
    public List<Character>? GetCharactersFORFilters(List<Filter> list)
    {
        List<int?> ids = new List<int?>();
        foreach (var filter in list) 
        {
            ids.Add(filter.Id);
        }
        return this.Characters
        .Where(c => c.FiltersToCharacters.Count(f => ids.Contains(f.FilterId)) == ids.Count)
        .ToList();;
    }

    //get a user id based on a character they created
    public int GetUserId(Character character)
    {
        return this.AppUsers.Where(c => c.Characters.Contains(character)).FirstOrDefault().Id;
    }

    //get the explanation a user made in their appeal
    public string GetAppeal(AppUser user)
    {
        Appeal appeal = this.Appeals.Where(c => c.UserId == user.Id).FirstOrDefault();
        return appeal.Explanation;
    }

    //get the reason a user was banned
    public string GetBanReason(AppUser user)
    {
        BanReason banReason = this.BanReasons.Where(c => c.UserId == user.Id).FirstOrDefault();
        return banReason.Reason;
    }

    //get all appeals
    public List<Appeal>? GetAllAppeals()
    {
        return this.Appeals.ToList();
    }

    //get all characters
    public List<Character>? GetAllCharactersA()
    {
        return this.Characters.ToList();
    }

    //public List<Class>? GetAllClasses(Character character)
    //{
    //    return this.Classes.Where(u => u.CharacterId == character.Id).ToList();
    //}

    //public Race? GetRace(Character character)
    //{
    //    return this.Races.Where(u => u.Id == character.Id).FirstOrDefault();
    //}

    //public ProficienciesSkill? GetSkills(Character character)
    //{
    //    return this.ProficienciesSkills.Where(u => u.Id == character.Id).FirstOrDefault();
    //}

    //public void RemoveAllClasses(Character character)
    //{
    //    this.Classes.Where(u => u.CharacterId == character.Id).ExecuteDelete();
    //}

    //public void RemoveRace(Character character)
    //{
    //    this.Races.Where(u => u.Id == character.Id).ExecuteDelete();
    //}

    //public void RemoveSkills(Character character)
    //{
    //    this.ProficienciesSkills.Where(u => u.Id == character.Id).ExecuteDelete();
    //}
}


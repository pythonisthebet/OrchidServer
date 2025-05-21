using System;
using System.Collections.Generic;
using System.Linq;
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

    public List<Filter>? GetAllFilters()
    {
        return this.Filters.ToList();
    }

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
    public int? GetUserId(Character character)
    {
        return this.AppUsers.Where(c => c.Characters.Contains(character)).FirstOrDefault().Id;
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


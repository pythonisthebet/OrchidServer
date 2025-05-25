using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OrchidServer.Models;

namespace OrchidServer.DTO;

public class AppUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public bool IsPremium { get; set; }

    public DateTime PremiumUntil { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsBanned { get; set; }

    public AppUser() { }
    public AppUser(Models.AppUser model)
    {
        this.Id = model.Id;
        this.UserName = model.UserName;
        this.UserEmail = model.UserEmail;
        this.UserPassword = model.UserPassword;
        this.IsAdmin = model.IsAdmin;
        this.IsBanned = model.IsBanned;
        this.IsPremium = model.IsPremium;
        this.PremiumUntil = model.PremiumUntil;
    }

    public Models.AppUser GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.AppUser newModel = new Models.AppUser();
        newModel.Id = this.Id;
        newModel.UserName = this.UserName;
        newModel.UserEmail = this.UserEmail;
        newModel.UserPassword = this.UserPassword;
        newModel.IsPremium = this.IsPremium;
        newModel.PremiumUntil = this.PremiumUntil;
        newModel.IsAdmin = this.IsAdmin;
        newModel.IsBanned= this.IsBanned;
        return newModel;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Equipment
{
    public int Id { get; set; }
    public bool IsWeapon { get; set; }
    public bool IsArmor { get; set; }
    public bool IsShield { get; set; }
    public bool IsAttunment { get; set; }

    public Equipment() { }
    public Equipment(Models.Equipment model)
    {
        this.Id = model.Id;
        this.IsWeapon = model.IsWeapon;
        this.IsArmor = model.IsArmor;
        this.IsShield = model.IsShield;
        this.IsAttunment = model.IsAttunment;
    }

    public Models.Equipment GetModel()
    {
        Models.Equipment newModel = new Models.Equipment();
        newModel.Id = this.Id;
        newModel.IsWeapon = this.IsWeapon;
        newModel.IsArmor = this.IsArmor;
        newModel.IsShield = this.IsShield;
        newModel.IsAttunment = this.IsAttunment;
        return newModel;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class EquipRarity
{
    public int Id { get; set; }

    public string Rname { get; set; } = null!;

    public EquipRarity() { }
    public EquipRarity(Models.EquipRarity model)
    {
        this.Id = model.Id;
        this.Rname = model.Rname;
    }

    public Models.EquipRarity GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.EquipRarity newModel = new Models.EquipRarity();
        newModel.Id = this.Id;
        newModel.Rname = this.Rname;
        return newModel;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Spell
{
    public int Id { get; set; }

    public string SName { get; set; } = null!;

    public int SLevel { get; set; }

    public string SDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    public Spell() { }

    public Spell(Models.Spell model)
    {
        this.Id = model.Id;
        this.SName = model.SName;
        this.SLevel = model.SLevel;
        this.SDescription = model.SDescription;
        this.IsOfficial = model.IsOfficial;
    }

    public Models.Spell GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Spell newModel = new Models.Spell();
        newModel.Id = this.Id;
        newModel.SName = this.SName;
        newModel.SLevel = this.SLevel;
        newModel.SDescription = this.SDescription;
        newModel.IsOfficial = this.IsOfficial;
        return newModel;
    }
}

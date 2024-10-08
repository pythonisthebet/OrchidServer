using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Skill
{
    public int Id { get; set; }

    public string Sname { get; set; } = null!;

    public int? Stat { get; set; }

    public Skill() { }

    public Skill(Models.Skill model)
    {
        this.Id = model.Id;
        this.Sname = model.Sname;
        this.Stat = model.Stat;
    }

    public Models.Skill GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Skill newModel = new Models.Skill();
        newModel.Id = this.Id;
        newModel.Sname = this.Sname;
        newModel.Stat = this.Stat;
        return newModel;
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Spell
{
    public int Id { get; set; }

    public string SpellName { get; set; } = null!;

    public int SpellLevel { get; set; }

    public Spell() { }

    public Spell(Models.Spell model)
    {
        this.Id = model.Id;
        this.SpellName = model.SpellName;
        this.SpellLevel = model.SpellLevel;
    }

    public Models.Spell GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Spell newModel = new Models.Spell();
        newModel.Id = this.Id;
        newModel.SpellName = this.SpellName;
        newModel.SpellLevel = this.SpellLevel;
        return newModel;
    }
}

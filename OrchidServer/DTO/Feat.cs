using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Feat
{
    public int Id { get; set; }
    public int? Character_id { get; set; }
    public string FeatName { get; set; } = null!;
    public int LevelTaken { get; set; }

    public Feat() { }

    public Feat(Models.Feat model)
    {
        this.Id = model.Id;
        this.Character_id = model.CharacterId;
        this.FeatName = model.FeatName;
        this.LevelTaken = model.LevelTaken;
    }

    public Models.Feat GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Feat newModel = new Models.Feat();
        newModel.Id = this.Id;
        newModel.CharacterId = this.Character_id;
        newModel.FeatName = this.FeatName;
        newModel.LevelTaken = this.LevelTaken;
        return newModel;
    }
}

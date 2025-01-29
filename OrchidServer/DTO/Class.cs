using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Class
{
    public int Id { get; set; }
    public int? Character_id { get; set; }
    public string ClassName { get; set; } = null!;
    public string SubclassName { get; set; } = null!;
    public int LevelValue { get; set; }

    public Class() { }
    public Class(Models.Class model)
    {
        this.Id = model.Id;
        this.Character_id = model.CharacterId;
        this.ClassName = model.ClassName;
        this.SubclassName = model.SubclassName;
        this.LevelValue = model.LevelValue;

    }

    public Models.Class GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Class newModel = new Models.Class();
        newModel.Id = this.Id;
        newModel.CharacterId = this.Character_id;
        newModel.ClassName = this.ClassName;
        newModel.SubclassName = this.SubclassName;
        newModel.LevelValue = this.LevelValue;


        return newModel;
    }
}

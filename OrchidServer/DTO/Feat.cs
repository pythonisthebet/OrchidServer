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

    public string FName { get; set; } = null!;

    public string FDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    public Feat() { }

    public Feat(Models.Feat model)
    {
        this.Id = model.Id;
        this.FName = model.FName;
        this.FDescription = model.FDescription;
        this.IsOfficial = model.IsOfficial;
    }

    public Models.Feat GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Feat newModel = new Models.Feat();
        newModel.Id = this.Id;
        newModel.FName = this.FName;
        newModel.FDescription = this.FDescription;
        newModel.IsOfficial = this.IsOfficial;
        return newModel;
    }
}

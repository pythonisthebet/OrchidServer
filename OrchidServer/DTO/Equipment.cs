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

    public int? TypeId { get; set; }

    public int? RarityId { get; set; }

    public string EDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    public Equipment() { }
    public Equipment(Models.Equipment model)
    {
        this.Id = model.Id;
        this.TypeId = model.TypeId;
        this.RarityId = model.RarityId;
        this.EDescription = model.EDescription;
        this.IsOfficial = model.IsOfficial;
    }

    public Models.Equipment GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Equipment newModel = new Models.Equipment();
        newModel.Id = this.Id;
        newModel.TypeId = this.TypeId;
        newModel.RarityId = this.RarityId;
        newModel.EDescription = this.EDescription;
        newModel.IsOfficial = this.IsOfficial;
        return newModel;
    }
}

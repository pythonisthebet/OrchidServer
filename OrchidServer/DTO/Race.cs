using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Race
{
    public int Id { get; set; }

    public string RName { get; set; } = null!;

    public string RDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    public Race() { }

    public Race(Models.Race model)
    {
        this.Id = model.Id;
        this.RName = model.RName;
        this.RDescription = model.RDescription;
        this.IsOfficial = model.IsOfficial;
    }

    public Models.Race GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Race newModel = new Models.Race();
        newModel.Id = this.Id;
        newModel.RName = this.RName;
        newModel.RDescription = this.RDescription;
        newModel.IsOfficial = this.IsOfficial;
        return newModel;
    }
}

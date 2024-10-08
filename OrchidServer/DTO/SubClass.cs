using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;


public class SubClass
{
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public string SubCName { get; set; } = null!;

    public string SubCDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    public SubClass() { }

    public SubClass(Models.SubClass model)
    {
        this.Id = model.Id;
        this.ClassId = model.ClassId;
        this.SubCName = model.SubCName;
        this.SubCDescription = model.SubCDescription;
        this.IsOfficial = model.IsOfficial;
    }

    public Models.SubClass GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.SubClass newModel = new Models.SubClass();
        newModel.Id = this.Id;
        newModel.ClassId = this.ClassId;
        newModel.SubCName = this.SubCName;
        newModel.SubCDescription = this.SubCDescription;
        newModel.IsOfficial = this.IsOfficial;
        return newModel;
    }
}

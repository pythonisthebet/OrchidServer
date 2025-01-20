using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class EquipType
{
    //public int Id { get; set; }
    //public string Tname { get; set; } = null!;

    //public EquipType() { }

    //public EquipType(Models.EquipType model)
    //{
    //    this.Id = model.Id;
    //    this.Tname = model.Tname;
    //}

    //public Models.EquipType GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    //{
    //    Models.EquipType newModel = new Models.EquipType();
    //    newModel.Id = this.Id;
    //    newModel.Tname = this.Tname;
    //    return newModel;
    //}
}

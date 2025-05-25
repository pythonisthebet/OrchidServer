using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;
namespace OrchidServer.DTO;

public class BanReason
{
    public int Id { get; set; }

    public int? UserId { get; set; }
    public string Reason { get; set; } = null!;

    public BanReason() { }
    public BanReason(Models.BanReason modelAppeal)
    {
        this.Id = modelAppeal.Id;
        this.UserId = modelAppeal.UserId;
        this.Reason = modelAppeal.Reason;
    }

    public Models.BanReason GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.BanReason newModel = new Models.BanReason();
        newModel.Id = this.Id;
        newModel.UserId = this.UserId;
        newModel.Reason = this.Reason;

        return newModel;
    }
}


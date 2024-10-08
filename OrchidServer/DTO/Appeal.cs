using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;
namespace OrchidServer.DTO;

public class Appeal
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Reason { get; set; } = null!;

    public string Explanation { get; set; } = null!;

    public Appeal() { }
    public Appeal(Models.Appeal modelAppeal)
    {
        this.Id = modelAppeal.Id;
        this.UserId = modelAppeal.UserId;
        this.Reason = modelAppeal.Reason;
        this.Explanation = modelAppeal.Explanation;
    }

    public Models.Appeal GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Appeal newModel = new Models.Appeal();
        newModel.Id = this.Id;
        newModel.UserId = this.UserId;
        newModel.Reason = this.Reason;
        newModel.Reason = this.Explanation;

        return newModel;
    }
}

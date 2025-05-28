using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Party
{
    public int Id { get; set; }

    public int? DmId { get; set; }

    public string Pname { get; set; } = null!;

    public string? CurrentCampain { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();

    public Party() { }

    public Party(Models.Party model)
    {
        this.Id = model.Id;
        this.Pname = model.Pname;
        this.DmId = model.DmId;
        this.CurrentCampain = model.CurrentCampain;
        //foreach (var user in model.) // add list of participents like ofer did with his appuser in Taskmenegmnt system
        //{
        //    this.UserTasks.Add(new UserTask(task));
        //}
        }

    public Models.Party GetModel()
    {
        Models.Party newModel = new Models.Party();
        newModel.Id = this.Id;
        newModel.Pname = this.Pname;
        newModel.DmId = this.DmId;
        newModel.CurrentCampain = this.CurrentCampain;
        return newModel;
    }
}

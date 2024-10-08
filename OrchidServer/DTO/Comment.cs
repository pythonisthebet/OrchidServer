using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public string CommentBody { get; set; } = null!;

    public int? Likes { get; set; }

    public Comment() { }
    public Comment(Models.Comment model)
    {
        this.Id = model.Id;
        this.UserId = model.UserId;
        this.PostId = model.PostId;
        this.CommentBody = model.CommentBody;
        this.Likes = model.Likes;
    }

    public Models.Comment GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
    {
        Models.Comment newModel = new Models.Comment();
        newModel.Id = this.Id;
        newModel.UserId = this.UserId;
        newModel.PostId = this.PostId;
        newModel.CommentBody = this.CommentBody;
        newModel.Likes = this.Likes;
        return newModel;
    }
}

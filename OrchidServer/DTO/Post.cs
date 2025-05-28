using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class Post
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public int? Forum { get; set; }

    public string PostBody { get; set; } = null!;

    public int? Likes { get; set; }

    public int? Pviews { get; set; }

    public Post() { }

    public Post(Models.Post model)
    {
        this.Id = model.Id;
        this.UserId = model.UserId;
        this.Title = model.Title;
        this.Forum = model.Forum;
        this.PostBody = model.PostBody;
        this.Likes = model.Likes;
        this.Pviews = model.Pviews;
    }

    public Models.Post GetModel()
    {
        Models.Post newModel = new Models.Post();
        newModel.Id = this.Id;
        newModel.UserId = this.UserId;
        newModel.Title = this.Title;
        newModel.Forum = this.Forum;
        newModel.PostBody = this.PostBody;
        newModel.Likes = this.Likes;
        newModel.Pviews = this.Pviews;
        return newModel;
    }
}

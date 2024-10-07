using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Comment
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    [StringLength(1000)]
    public string CommentBody { get; set; } = null!;

    public int? Likes { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("Comments")]
    public virtual Post? Post { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Comments")]
    public virtual AppUser? User { get; set; }
}

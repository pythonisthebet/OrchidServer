using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Post
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [StringLength(20)]
    public string Title { get; set; } = null!;

    public int? Forum { get; set; }

    [StringLength(1000)]
    public string PostBody { get; set; } = null!;

    public int? Likes { get; set; }

    [Column("PViews")]
    public int? Pviews { get; set; }

    [InverseProperty("Post")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [ForeignKey("Forum")]
    [InverseProperty("Posts")]
    public virtual Forum? ForumNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Posts")]
    public virtual AppUser? User { get; set; }
}

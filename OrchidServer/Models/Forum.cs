using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Forum
{
    [Key]
    public int Id { get; set; }

    [Column("FName")]
    [StringLength(20)]
    public string Fname { get; set; } = null!;

    [InverseProperty("ForumNavigation")]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}

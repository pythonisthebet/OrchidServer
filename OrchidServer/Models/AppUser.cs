﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Index("UserEmail", Name = "UQ__AppUsers__08638DF8B95D5295", IsUnique = true)]
public partial class AppUser
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string UserEmail { get; set; } = null!;

    [StringLength(12)]
    public string UserPassword { get; set; } = null!;

    public bool IsPremium { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PremiumUntil { get; set; }

    public bool IsAdmin { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();

    [InverseProperty("User")]
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    [InverseProperty("User")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [InverseProperty("User")]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}

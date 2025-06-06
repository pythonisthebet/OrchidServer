﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Index("UserEmail", Name = "UQ__AppUsers__08638DF84A12B959", IsUnique = true)]
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

    public bool IsBanned { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();

    [InverseProperty("User")]
    public virtual ICollection<BanReason> BanReasons { get; set; } = new List<BanReason>();

    [InverseProperty("User")]
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}

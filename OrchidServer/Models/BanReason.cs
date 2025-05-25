using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class BanReason
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [StringLength(4000)]
    public string Reason { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("BanReasons")]
    public virtual AppUser? User { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Appeal
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [StringLength(100)]
    public string Reason { get; set; } = null!;

    [StringLength(100)]
    public string Explanation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Appeals")]
    public virtual AppUser? User { get; set; }
}

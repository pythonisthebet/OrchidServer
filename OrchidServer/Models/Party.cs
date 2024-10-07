using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Party
{
    [Key]
    public int Id { get; set; }

    public int? DmId { get; set; }

    [Column("PName")]
    [StringLength(20)]
    public string Pname { get; set; } = null!;

    [Column("Current_Campain")]
    [StringLength(30)]
    public string? CurrentCampain { get; set; }

    [ForeignKey("DmId")]
    [InverseProperty("Parties")]
    public virtual AppUser? Dm { get; set; }
}

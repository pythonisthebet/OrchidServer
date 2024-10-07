using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Index("FName", Name = "UQ__Feats__423F2C5B1233EC5A", IsUnique = true)]
public partial class Feat
{
    [Key]
    public int Id { get; set; }

    [Column("F_Name")]
    [StringLength(50)]
    public string FName { get; set; } = null!;

    [Column("F_Description")]
    [StringLength(4000)]
    public string FDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }
}

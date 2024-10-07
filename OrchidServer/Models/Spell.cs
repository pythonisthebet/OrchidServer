using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Index("SName", Name = "UQ__Spells__A21ED07D6A7B1038", IsUnique = true)]
public partial class Spell
{
    [Key]
    public int Id { get; set; }

    [Column("S_Name")]
    [StringLength(50)]
    public string SName { get; set; } = null!;

    [Column("S_Level")]
    public int SLevel { get; set; }

    [Column("S_Description")]
    [StringLength(4000)]
    public string SDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }
}

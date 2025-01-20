using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Spell
{
    [Key]
    public int Id { get; set; }

    [Column("Spell_Name")]
    [StringLength(50)]
    public string SpellName { get; set; } = null!;

    [Column("Spell_Level")]
    public int SpellLevel { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Spell")]
    public virtual Character IdNavigation { get; set; } = null!;
}

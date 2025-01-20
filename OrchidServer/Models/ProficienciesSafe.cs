using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_saves")]
public partial class ProficienciesSafe
{
    [Key]
    public int Id { get; set; }

    public bool Strength { get; set; }

    public bool Dexterity { get; set; }

    public bool Constitution { get; set; }

    public bool Intelligence { get; set; }

    public bool Wisdom { get; set; }

    public bool Charisma { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesSafe")]
    public virtual Character IdNavigation { get; set; } = null!;
}

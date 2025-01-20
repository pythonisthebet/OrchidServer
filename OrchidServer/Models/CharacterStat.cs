using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Character_Stats")]
public partial class CharacterStat
{
    [Key]
    public int Id { get; set; }

    public int Strength { get; set; }

    public int Dexterity { get; set; }

    public int Constitution { get; set; }

    public int Intelligence { get; set; }

    public int Wisdom { get; set; }

    public int Charisma { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("CharacterStat")]
    public virtual Character IdNavigation { get; set; } = null!;
}

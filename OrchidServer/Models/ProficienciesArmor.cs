using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_Armors")]
public partial class ProficienciesArmor
{
    [Key]
    public int Id { get; set; }

    [Column("All_Armor")]
    public bool AllArmor { get; set; }

    [Column("Heavy_Armor")]
    public bool HeavyArmor { get; set; }

    [Column("Medium_Armor")]
    public bool MediumArmor { get; set; }

    [Column("Light_Armor")]
    public bool LightArmor { get; set; }

    public bool Shield { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesArmor")]
    public virtual Character IdNavigation { get; set; } = null!;
}

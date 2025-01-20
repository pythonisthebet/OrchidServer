using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_Armours")]
public partial class ProficienciesArmour
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

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesArmour")]
    public virtual Character IdNavigation { get; set; } = null!;
}

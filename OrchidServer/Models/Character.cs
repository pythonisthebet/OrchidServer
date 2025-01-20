using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Character
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [Column("Level_Value")]
    public int LevelValue { get; set; }

    [Column("img_id")]
    [StringLength(100)]
    public string? ImgId { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual CharacterStat? CharacterStat { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Class? Class { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Equipment? Equipment { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Feat? Feat { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesArmour? ProficienciesArmour { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesLanguage? ProficienciesLanguage { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesSafe? ProficienciesSafe { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesSkill? ProficienciesSkill { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesTool? ProficienciesTool { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesWeapon? ProficienciesWeapon { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Race? Race { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Spell? Spell { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Characters")]
    public virtual AppUser? User { get; set; }
}

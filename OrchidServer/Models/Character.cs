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

    [Column("Character_Name")]
    [StringLength(50)]
    public string CharacterName { get; set; } = null!;

    [Column("Level_Value")]
    public int LevelValue { get; set; }

    [Column("img_id")]
    [StringLength(100)]
    public string? ImgId { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual CharacterStat? CharacterStat { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("IdNavigation")]
    public virtual Equipment? Equipment { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<Feat> Feats { get; set; } = new List<Feat>();

    [InverseProperty("IdNavigation")]
    public virtual ProficienciesArmor? ProficienciesArmor { get; set; }

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

    [InverseProperty("Character")]
    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();

    [ForeignKey("UserId")]
    [InverseProperty("Characters")]
    public virtual AppUser? User { get; set; }
}

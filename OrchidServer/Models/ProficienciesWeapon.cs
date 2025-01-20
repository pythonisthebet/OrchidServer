using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_Weapons")]
public partial class ProficienciesWeapon
{
    [Key]
    public int Id { get; set; }

    [Column("Simple_Weapons")]
    public bool SimpleWeapons { get; set; }

    [Column("Martial_Weapons")]
    public bool MartialWeapons { get; set; }

    public bool Club { get; set; }

    public bool Dagger { get; set; }

    public bool Greatclub { get; set; }

    public bool Handaxe { get; set; }

    public bool Javelin { get; set; }

    [Column("Light_hammer")]
    public bool LightHammer { get; set; }

    public bool Mace { get; set; }

    public bool Quarterstaff { get; set; }

    public bool Sickle { get; set; }

    public bool Spear { get; set; }

    [Column("Light_Crossbow")]
    public bool LightCrossbow { get; set; }

    public bool Dart { get; set; }

    public bool Shortbow { get; set; }

    public bool Sling { get; set; }

    public bool Battleaxe { get; set; }

    public bool Flail { get; set; }

    public bool Glaive { get; set; }

    public bool Greataxe { get; set; }

    public bool Greatsword { get; set; }

    public bool Halberd { get; set; }

    public bool Lance { get; set; }

    public bool Longsword { get; set; }

    public bool Maul { get; set; }

    public bool Morningstar { get; set; }

    public bool Pike { get; set; }

    public bool Rapier { get; set; }

    public bool Scimitar { get; set; }

    public bool Shortsword { get; set; }

    public bool Trident { get; set; }

    [Column("War_pick")]
    public bool WarPick { get; set; }

    public bool Warhammer { get; set; }

    public bool Whip { get; set; }

    public bool Blowgun { get; set; }

    [Column("Hand_Crossbow")]
    public bool HandCrossbow { get; set; }

    [Column("Heavy_Crossbow")]
    public bool HeavyCrossbow { get; set; }

    public bool Longbow { get; set; }

    public bool Net { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesWeapon")]
    public virtual Character IdNavigation { get; set; } = null!;
}

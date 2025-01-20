using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_Tools")]
public partial class ProficienciesTool
{
    [Key]
    public int Id { get; set; }

    [Column("Alchemists_supplies")]
    public bool AlchemistsSupplies { get; set; }

    [Column("Brewers_supplies")]
    public bool BrewersSupplies { get; set; }

    [Column("Calligraphers_supplies")]
    public bool CalligraphersSupplies { get; set; }

    [Column("Carpenters_tools")]
    public bool CarpentersTools { get; set; }

    [Column("Cartographers_tools")]
    public bool CartographersTools { get; set; }

    [Column("Cobblers_tools")]
    public bool CobblersTools { get; set; }

    [Column("Cooks_utensils")]
    public bool CooksUtensils { get; set; }

    [Column("Glassblowers_tools")]
    public bool GlassblowersTools { get; set; }

    [Column("Jewelers_tools")]
    public bool JewelersTools { get; set; }

    [Column("Leatherworkers_tools")]
    public bool LeatherworkersTools { get; set; }

    [Column("Masons_tools")]
    public bool MasonsTools { get; set; }

    [Column("Painters_supplies")]
    public bool PaintersSupplies { get; set; }

    [Column("Potters_tools")]
    public bool PottersTools { get; set; }

    [Column("Smiths_tools")]
    public bool SmithsTools { get; set; }

    [Column("Tinkers_tools")]
    public bool TinkersTools { get; set; }

    [Column("Weavers_tools")]
    public bool WeaversTools { get; set; }

    [Column("Woodcarvers_tools")]
    public bool WoodcarversTools { get; set; }

    [Column("Gaming_sets")]
    public bool GamingSets { get; set; }

    [Column("Dice_set")]
    public bool DiceSet { get; set; }

    [Column("Playing_card_set")]
    public bool PlayingCardSet { get; set; }

    [Column("Musical_instruments")]
    public bool MusicalInstruments { get; set; }

    public bool Bagpipes { get; set; }

    public bool Drum { get; set; }

    public bool Dulcimer { get; set; }

    public bool Flute { get; set; }

    public bool Lute { get; set; }

    public bool Lyre { get; set; }

    public bool Horn { get; set; }

    [Column("Pan_flute")]
    public bool PanFlute { get; set; }

    public bool Shawm { get; set; }

    public bool Viol { get; set; }

    [Column("Navigators_tools")]
    public bool NavigatorsTools { get; set; }

    [Column("Thieves_tools")]
    public bool ThievesTools { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesTool")]
    public virtual Character IdNavigation { get; set; } = null!;
}

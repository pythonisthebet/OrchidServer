using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_languages")]
public partial class ProficienciesLanguage
{
    [Key]
    public int Id { get; set; }

    public bool Common { get; set; }

    public bool Dwarvish { get; set; }

    public bool Elvish { get; set; }

    public bool Giant { get; set; }

    public bool Gnomish { get; set; }

    public bool Goblin { get; set; }

    public bool Halfling { get; set; }

    [Column("Orc_language")]
    public bool OrcLanguage { get; set; }

    public bool Abyssal { get; set; }

    public bool Celestial { get; set; }

    public bool Draconic { get; set; }

    [Column("Deep_Speech")]
    public bool DeepSpeech { get; set; }

    public bool Infernal { get; set; }

    public bool Primodial { get; set; }

    public bool Sylvan { get; set; }

    public bool Undercommon { get; set; }

    public bool Druidic { get; set; }

    [Column("Thieves_Cant")]
    public bool ThievesCant { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesLanguage")]
    public virtual Character IdNavigation { get; set; } = null!;
}

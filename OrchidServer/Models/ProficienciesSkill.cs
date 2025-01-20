using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Proficiencies_skills")]
public partial class ProficienciesSkill
{
    [Key]
    public int Id { get; set; }

    public bool Acrobatics { get; set; }

    [Column("Animal_Handling")]
    public bool AnimalHandling { get; set; }

    public bool Arcana { get; set; }

    public bool Athletics { get; set; }

    public bool Deception { get; set; }

    public bool History { get; set; }

    public bool Insight { get; set; }

    public bool Intimidation { get; set; }

    public bool Investigation { get; set; }

    public bool Medicine { get; set; }

    public bool Nature { get; set; }

    public bool Perception { get; set; }

    public bool Performance { get; set; }

    public bool Persuasion { get; set; }

    public bool Religion { get; set; }

    [Column("Sleight_of_Hand")]
    public bool SleightOfHand { get; set; }

    public bool Stealth { get; set; }

    public bool Survival { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ProficienciesSkill")]
    public virtual Character IdNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

[Index("Sname", Name = "UQ__Skills__457BC2DADF8C118D", IsUnique = true)]
public partial class Skill
{
    [Key]
    public int Id { get; set; }

    [Column("SName")]
    [StringLength(10)]
    [Unicode(false)]
    public string Sname { get; set; } = null!;

    public int? Stat { get; set; }

    [ForeignKey("Stat")]
    [InverseProperty("Skills")]
    public virtual SkillStat? StatNavigation { get; set; }
}

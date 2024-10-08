using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

[Table("Skill_Stats")]
[Index("Sname", Name = "UQ__Skill_St__457BC2DAD74FDE66", IsUnique = true)]
public partial class SkillStat
{
    [Key]
    public int Id { get; set; }

    [Column("SName")]
    [StringLength(10)]
    [Unicode(false)]
    public string Sname { get; set; } = null!;

    [InverseProperty("StatNavigation")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

[Index("RName", Name = "UQ__Races__89ED98905C1D8BF9", IsUnique = true)]
public partial class Race
{
    [Key]
    public int Id { get; set; }

    [Column("R_Name")]
    [StringLength(50)]
    public string RName { get; set; } = null!;

    [Column("R_Description")]
    [StringLength(4000)]
    public string RDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    [InverseProperty("RaceNavigation")]
    public virtual ICollection<ChList> ChListRaceNavigations { get; set; } = new List<ChList>();

    [InverseProperty("SubclassNavigation")]
    public virtual ICollection<ChList> ChListSubclassNavigations { get; set; } = new List<ChList>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;










//outdated










[Table("Equip_Rarity")]
[Index("Rname", Name = "UQ__Equip_Ra__754413986A58A93B", IsUnique = true)]
public partial class EquipRarity
{
    [Key]
    public int Id { get; set; }

    [Column("RName")]
    [StringLength(10)]
    [Unicode(false)]
    public string Rname { get; set; } = null!;

    [InverseProperty("Rarity")]
    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}

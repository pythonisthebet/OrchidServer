using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;










//outdated










[Table("Equip_Type")]
[Index("Tname", Name = "UQ__Equip_Ty__8E5169F5BF5FC627", IsUnique = true)]
public partial class EquipType
{
    [Key]
    public int Id { get; set; }

    [Column("TName")]
    [StringLength(10)]
    [Unicode(false)]
    public string Tname { get; set; } = null!;

    [InverseProperty("Type")]
    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}

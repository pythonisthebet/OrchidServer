using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Equipment
{
    [Key]
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public int? RarityId { get; set; }

    [Column("E_Description")]
    [StringLength(2000)]
    public string EDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    [ForeignKey("RarityId")]
    [InverseProperty("Equipment")]
    public virtual EquipRarity? Rarity { get; set; }

    [ForeignKey("TypeId")]
    [InverseProperty("Equipment")]
    public virtual EquipType? Type { get; set; }
}

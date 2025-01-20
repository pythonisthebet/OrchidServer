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

    [Column("Is_Weapon")]
    public bool IsWeapon { get; set; }

    [Column("Is_Armor")]
    public bool IsArmor { get; set; }

    [Column("Is_Shield")]
    public bool IsShield { get; set; }

    [Column("Is_Attunment")]
    public bool IsAttunment { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Equipment")]
    public virtual Character IdNavigation { get; set; } = null!;
}

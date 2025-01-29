using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Class")]
public partial class Class
{
    [Key]
    public int Id { get; set; }

    [Column("Character_Id")]
    public int? CharacterId { get; set; }

    [Column("Class_Name")]
    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [Column("Subclass_Name")]
    [StringLength(4000)]
    public string SubclassName { get; set; } = null!;

    [Column("Level_Value")]
    public int LevelValue { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Classes")]
    public virtual Character? Character { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

[Table("Sub_Classes")]
[Index("SubCName", Name = "UQ__Sub_Clas__1989AE56E9FBD543", IsUnique = true)]
public partial class SubClass
{
    [Key]
    public int Id { get; set; }

    [Column("Class_Id")]
    public int? ClassId { get; set; }

    [Column("Sub_C_Name")]
    [StringLength(50)]
    public string SubCName { get; set; } = null!;

    [Column("Sub_C_Description")]
    [StringLength(4000)]
    public string SubCDescription { get; set; } = null!;

    public bool IsOfficial { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("SubClasses")]
    public virtual Class? Class { get; set; }
}

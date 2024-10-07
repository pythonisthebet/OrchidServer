using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Index("CName", Name = "UQ__Classes__3006C73674EC5C9B", IsUnique = true)]
public partial class Class
{
    [Key]
    public int Id { get; set; }

    [Column("C_Name")]
    [StringLength(50)]
    public string CName { get; set; } = null!;

    [Column("C_Description")]
    [StringLength(4000)]
    public string CDescription { get; set; } = null!;

    [InverseProperty("MainClassNavigation")]
    public virtual ICollection<ChList> ChLists { get; set; } = new List<ChList>();

    [InverseProperty("Class")]
    public virtual ICollection<SubClass> SubClasses { get; set; } = new List<SubClass>();
}

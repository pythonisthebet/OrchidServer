using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Filter
{
    [Key]
    public int Id { get; set; }

    [Column("FName")]
    [StringLength(20)]
    public string Fname { get; set; } = null!;

    [InverseProperty("Filter")]
    public virtual ICollection<FiltersToCharacter> FiltersToCharacters { get; set; } = new List<FiltersToCharacter>();
}

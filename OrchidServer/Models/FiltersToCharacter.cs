using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("FiltersToCharacter")]
public partial class FiltersToCharacter
{
    [Key]
    public int Id { get; set; }

    public int? CharacterId { get; set; }

    public int? FilterId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("FiltersToCharacters")]
    public virtual Character? Character { get; set; }

    [ForeignKey("FilterId")]
    [InverseProperty("FiltersToCharacters")]
    public virtual Filter? Filter { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Character
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [Column("Character_Name")]
    [StringLength(50)]
    public string CharacterName { get; set; } = null!;

    [Column("Level_Value")]
    public int LevelValue { get; set; }

    [Column("img_id")]
    [StringLength(100)]
    public string? ImgId { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<FiltersToCharacter> FiltersToCharacters { get; set; } = new List<FiltersToCharacter>();

    [ForeignKey("UserId")]
    [InverseProperty("Characters")]
    public virtual AppUser? User { get; set; }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class Feat
{
    [Key]
    public int Id { get; set; }

    [Column("Feat_Name")]
    [StringLength(50)]
    public string FeatName { get; set; } = null!;

    [Column("Level_taken")]
    public int LevelTaken { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Feat")]
    public virtual Character IdNavigation { get; set; } = null!;
}

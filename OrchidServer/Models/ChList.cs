using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Ch_List")]
public partial class ChList
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [Column("Main_Class")]
    public int? MainClass { get; set; }

    public int? Race { get; set; }

    public int? Subclass { get; set; }

    [Column("Level_Value")]
    public int LevelValue { get; set; }

    public bool IsMultiClass { get; set; }

    [Column("imgID")]
    public int? ImgId { get; set; }

    [ForeignKey("MainClass")]
    [InverseProperty("ChLists")]
    public virtual Class? MainClassNavigation { get; set; }

    [ForeignKey("Race")]
    [InverseProperty("ChListRaceNavigations")]
    public virtual Race? RaceNavigation { get; set; }

    [ForeignKey("Subclass")]
    [InverseProperty("ChListSubclassNavigations")]
    public virtual Race? SubclassNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ChLists")]
    public virtual AppUser? User { get; set; }
}

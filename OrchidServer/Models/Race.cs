using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Table("Race")]
public partial class Race
{
    [Key]
    public int Id { get; set; }

    [Column("Race_Name")]
    [StringLength(50)]
    public string RaceName { get; set; } = null!;

    [Column("Subrace_name")]
    [StringLength(50)]
    public string SubraceName { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("Race")]
    public virtual Cheracter IdNavigation { get; set; } = null!;
}

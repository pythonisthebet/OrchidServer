using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

[Keyless]
[Table("Partie_Users")]
public partial class PartieUser
{
    public int? UserId { get; set; }

    public int? PartyId { get; set; }

    [ForeignKey("PartyId")]
    public virtual Party? Party { get; set; }

    [ForeignKey("UserId")]
    public virtual AppUser? User { get; set; }
}

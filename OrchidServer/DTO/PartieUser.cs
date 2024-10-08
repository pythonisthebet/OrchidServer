using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using OrchidServer.Models;

namespace OrchidServer.DTO;

public class PartieUser// need to see if i need DTO for many to many
{
    //public int? UserId { get; set; }

    //public int? PartyId { get; set; }

    //[ForeignKey("PartyId")]
    //public virtual Party? Party { get; set; }

    //[ForeignKey("UserId")]
    //public virtual AppUser? User { get; set; }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class OrchidDbContext : DbContext
{
    public AppUser? GetUser(string email)
    {
        return this.AppUsers.Where(u => u.UserEmail == email)
                            .FirstOrDefault();
    }
}


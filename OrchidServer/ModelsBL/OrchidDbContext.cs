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

    public AppUser? GetUserById(int id)
    {
        return this.AppUsers.Where(u => u.Id == id)
                            .FirstOrDefault();
    }

    public List<AppUser>? GetAllUsersC()
    {
        return this.AppUsers.ToList();
    }
}


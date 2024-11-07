﻿using Microsoft.EntityFrameworkCore;
using UngDungHenHo.Entities;

namespace UngDungHenHo.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}

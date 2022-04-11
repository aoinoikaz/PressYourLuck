﻿using Microsoft.EntityFrameworkCore;
using PressYourLuck.Models;

namespace PressYourLuck.Data
{
    public class AuditContext : DbContext
    {
        public AuditContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Audit> Audit { get; set; }

        public DbSet<AuditType> AuditType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditType>().HasData(
                new AuditType() 
                { 
                    AuditTypeId = 1, 
                    Name = "Cash In"
                },
                new AuditType()
                {
                    AuditTypeId = 2,
                    Name = "Cash Out"
                },
                new AuditType()
                {
                    AuditTypeId = 3,
                    Name = "Win"
                },
                new AuditType()
                {
                    AuditTypeId = 4,
                    Name = "Lose"
                }
            );
        }
    }
}
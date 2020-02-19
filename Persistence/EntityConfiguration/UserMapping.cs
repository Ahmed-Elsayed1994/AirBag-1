using CoreData.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Persistence.EntityConfiguration
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => new { u.UserName, u.Email }).IsUnique();

        }
    }
}

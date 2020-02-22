using CoreData.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfiguration
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => new { u.UserName, u.Email }).IsUnique();
            builder.HasMany(a => a.Rates).WithOne(b => b.User);
            builder.HasMany(a => a.MyRates).WithOne(b => b.UserRateTo).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.Invitations).WithOne(b => b.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.MyInvitations).WithOne(b => b.UserInviteTo).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.ApprovedItems).WithOne(b => b.ApprovedUser).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.ApprovedBags).WithOne(b => b.ApprovedUser).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

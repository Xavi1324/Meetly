using Meetly.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Infrastructure.Persistence.Contexts
{
    public class MeetlyContext : DbContext
    {
        public MeetlyContext(DbContextOptions<MeetlyContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Posts>().ToTable("Posts");
            modelBuilder.Entity<Comments>().ToTable("Comments");
            modelBuilder.Entity<Friendship>().ToTable("Friendships");
            #endregion

            #region PrimaryKeys
            modelBuilder.Entity<Users>().HasKey(u => u.Id);
            modelBuilder.Entity<Posts>().HasKey(p => p.Id);
            modelBuilder.Entity<Comments>().HasKey(c => c.Id);
            modelBuilder.Entity<Friendship>().HasKey(f => f.Id);
            #endregion

            #region Users 
            modelBuilder.Entity<Users>(entity=> 
            {
                entity.Property(u => u.Name).IsRequired().HasMaxLength(50);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.ProfilePicture).IsRequired().HasMaxLength(250);
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(50);
                entity.HasIndex(u => u.UserName).IsUnique();
                entity.Property(u => u.Password).IsRequired().HasMaxLength(256);
                entity.Property(u => u.isActive).IsRequired().HasDefaultValue(false);

            });
            #endregion

            #region Posts
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(p => p.Content).IsRequired().HasMaxLength(500);
                entity.Property(p => p.PublishingTime).IsRequired().HasDefaultValueSql("GETDATE()");

                entity.HasOne(p => p.User)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region Comments
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(c => c.CommmentContent).IsRequired().HasMaxLength(500);
                entity.Property(c => c.CommentTime).IsRequired().HasDefaultValueSql("GETDATE()");
                entity.HasOne(c => c.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(c => c.PostId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(c => c.ParentComment)
                      .WithMany(c => c.Replies)
                      .HasForeignKey(c => c.ParentCommentId)
                      .OnDelete(DeleteBehavior.Restrict);

            });
            #endregion

            #region Friendship
            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.Property(f => f.UserId).IsRequired();
                entity.Property(f => f.FriendId).IsRequired();
                entity.HasOne(f => f.User)
                      .WithMany(u => u.FriendshipsAsUser)
                      .HasForeignKey(f => f.UserId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(f => f.Friend)
                      .WithMany(u => u.FriendshipsAsFriend)
                        .HasForeignKey(f => f.FriendId)
                        .OnDelete(DeleteBehavior.NoAction);
                entity.HasIndex(f => new { f.UserId, f.FriendId }).IsUnique();
            });

            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }
}

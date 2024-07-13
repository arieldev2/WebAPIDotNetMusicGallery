using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicGallery.Models
{
    public partial class MusicGalleryDBContext : DbContext
    {
        public MusicGalleryDBContext()
        {
        }

        public MusicGalleryDBContext(DbContextOptions<MusicGalleryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(b => b.Artist)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

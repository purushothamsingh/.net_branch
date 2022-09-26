using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIConcept.Models
{
    public partial class SampleGroceryContext : DbContext
    {
        public SampleGroceryContext()
        {
        }

        public SampleGroceryContext(DbContextOptions<SampleGroceryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grocery> Groceries { get; set; } = null!;
        public virtual DbSet<Usertbl> Usertbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=SampleGrocery;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grocery>(entity =>
            {
                entity.ToTable("Grocery");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductDesc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("productDesc");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("productImage");

                entity.Property(e => e.ProductTitle)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Groceries)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Grocery__userid__30F848ED");
            });

            modelBuilder.Entity<Usertbl>(entity =>
            {
                entity.ToTable("Usertbl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ModelTest.Models
{
    public partial class DB_TestHummanContext : DbContext
    {
        public DB_TestHummanContext()
        {
        }

        public DB_TestHummanContext(DbContextOptions<DB_TestHummanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Inventary> Inventaries { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DB_TestHumman;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("count");

                entity.Property(e => e.Pount)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("pount");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__accounts__rolId__38996AB5");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("articles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.LastNames)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("lastNames");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__clients__account__3B75D760");
            });

            modelBuilder.Entity<Inventary>(entity =>
            {
                entity.ToTable("inventary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Inventaries)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__inventary__artic__4222D4EF");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventaries)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__inventary__store__4316F928");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rols");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.InventaryId).HasColumnName("inventaryId");

                entity.Property(e => e.Pieces).HasColumnName("pieces");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__sales__clientId__45F365D3");

                entity.HasOne(d => d.Inventary)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.InventaryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__sales__inventary__46E78A0C");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("stores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.BranchOffice)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("branchOffice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

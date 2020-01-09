using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cinema.DAL.Models
{
    public partial class CinemaBookingDBContext : DbContext
    {
        public CinemaBookingDBContext()
        {
        }

        public CinemaBookingDBContext(DbContextOptions<CinemaBookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBookingSeat> TblBookingSeat { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblErrorLog> TblErrorLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=xx.xx.xx.xxx;Initial Catalog=CinemaBookingDB;User ID=xx;Password=xxxx");
                //optionsBuilder.UseSqlServer(new GetMessagesFromAppSetting<string>().GetMessageFromConfiguration("ConnectionStrings", "DefaultConnection"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBookingSeat>(entity =>
            {
                entity.ToTable("tblBookingSeat");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("tblCustomer");

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.SecretKey).HasMaxLength(50);
            });

            modelBuilder.Entity<TblErrorLog>(entity =>
            {
                entity.ToTable("tblErrorLog");

                entity.Property(e => e.Controller).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Method).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

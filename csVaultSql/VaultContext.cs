using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace csVaultSql
{
    public partial class VaultContext : DbContext
    {
        public VaultContext()
        {
        }

        public VaultContext(DbContextOptions<VaultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<csVaultSql.Models.Adcp> Adcps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Host=192.168.1.170;Database=Vault;Username=postgres;Password=my_pass");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<csVaultSql.Models.Adcp>(entity =>
            {
                entity.ToTable("adcps");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Application)
                    .HasColumnType("character varying")
                    .HasColumnName("application");

                entity.Property(e => e.Boardorientation)
                    .HasColumnType("character varying")
                    .HasColumnName("boardorientation");

                entity.Property(e => e.Cablelength)
                    .HasColumnType("character varying")
                    .HasColumnName("cablelength");

                entity.Property(e => e.Connectortype)
                    .HasColumnType("character varying")
                    .HasColumnName("connectortype");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Customer)
                    .HasColumnType("character varying")
                    .HasColumnName("customer");

                entity.Property(e => e.Depthrating)
                    .HasColumnType("character varying")
                    .HasColumnName("depthrating");

                entity.Property(e => e.Ethernetinstalled).HasColumnName("ethernetinstalled");

                entity.Property(e => e.Firmware)
                    .HasColumnType("character varying")
                    .HasColumnName("firmware");

                entity.Property(e => e.Frequency)
                    .HasColumnType("character varying")
                    .HasColumnName("frequency");

                entity.Property(e => e.Hardware)
                    .HasColumnType("character varying")
                    .HasColumnName("hardware");

                entity.Property(e => e.Headtype)
                    .HasColumnType("character varying")
                    .HasColumnName("headtype");

                entity.Property(e => e.Housingtype)
                    .HasColumnType("character varying")
                    .HasColumnName("housingtype");

                entity.Property(e => e.Isriversystem).HasColumnName("isriversystem");

                entity.Property(e => e.Istriggerin).HasColumnName("istriggerin");

                entity.Property(e => e.Istriggerout).HasColumnName("istriggerout");

                entity.Property(e => e.Isvesselmount).HasColumnName("isvesselmount");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Numbatts)
                    .HasColumnType("character varying")
                    .HasColumnName("numbatts");

                entity.Property(e => e.Ordernumber)
                    .HasColumnType("character varying")
                    .HasColumnName("ordernumber");

                entity.Property(e => e.Pressuresensorpresent).HasColumnName("pressuresensorpresent");

                entity.Property(e => e.Pressuresensorrating)
                    .HasColumnType("character varying")
                    .HasColumnName("pressuresensorrating");

                entity.Property(e => e.Productnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("productnumber");

                entity.Property(e => e.Recorderformatted).HasColumnName("recorderformatted");

                entity.Property(e => e.Recordersize)
                    .HasColumnType("character varying")
                    .HasColumnName("recordersize");

                entity.Property(e => e.Rmanumber)
                    .HasColumnType("character varying")
                    .HasColumnName("rmanumber");

                entity.Property(e => e.Scalefactor)
                    .HasColumnType("character varying")
                    .HasColumnName("scalefactor");

                entity.Property(e => e.Serialnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("serialnumber");

                entity.Property(e => e.Software)
                    .HasColumnType("character varying")
                    .HasColumnName("software");

                entity.Property(e => e.Systemtype)
                    .HasColumnType("character varying")
                    .HasColumnName("systemtype");

                entity.Property(e => e.Temperaturepresent).HasColumnName("temperaturepresent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

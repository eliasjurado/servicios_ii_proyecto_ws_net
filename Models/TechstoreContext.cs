using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace techstore_ws.Models
{
    public partial class TechstoreContext : DbContext
    {
        public TechstoreContext()
        {
        }

        public TechstoreContext(DbContextOptions<TechstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<CompraCabecera> CompraCabecera { get; set; }
        public virtual DbSet<CompraDetalle> CompraDetalle { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TechstoreConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK_CARGO");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.NomCargo)
                    .IsRequired()
                    .HasColumnName("nomCargo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK_CATEGORIA");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomCategoria)
                    .IsRequired()
                    .HasColumnName("nomCategoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_CLIENTE");

                entity.HasIndex(e => e.DniCliente)
                    .HasName("UNQ_DNI_CLI")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.ApeCliente)
                    .IsRequired()
                    .HasColumnName("apeCliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DirecCliente)
                    .IsRequired()
                    .HasColumnName("direcCliente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DniCliente)
                    .IsRequired()
                    .HasColumnName("dniCliente")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmailCliente)
                    .IsRequired()
                    .HasColumnName("emailCliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");

                entity.Property(e => e.IdTipoUsuario)
                    .HasColumnName("idTipoUsuario")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.NomCliente)
                    .IsRequired()
                    .HasColumnName("nomCliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassCliente)
                    .IsRequired()
                    .HasColumnName("passCliente")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TlfCliente)
                    .HasColumnName("tlfCliente")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIST_CLI");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPOUSU_CLI");
            });

            modelBuilder.Entity<CompraCabecera>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK_COMPRACABE");

                entity.ToTable("Compra_Cabecera");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.EstComp).HasColumnName("est_comp");

                entity.Property(e => e.FecEntComp)
                    .HasColumnName("fec_ent_comp")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecPedComp)
                    .HasColumnName("fec_ped_comp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CompraCabecera)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLI_COMPRA");
            });

            modelBuilder.Entity<CompraDetalle>(entity =>
            {
                entity.HasKey(e => new { e.IdCompra, e.IdProducto })
                    .HasName("PK_COMPRADETA");

                entity.ToTable("Compra_Detalle");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.CompraDetalle)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPCABE_DETA");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CompraDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_DETA");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito)
                    .HasName("PK_DISTRITO");

                entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");

                entity.Property(e => e.NomDistrito)
                    .IsRequired()
                    .HasColumnName("nomDistrito")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK_EMPLEADO");

                entity.HasIndex(e => e.DniEmpleado)
                    .HasName("UNQ_DNI_EMP")
                    .IsUnique();

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.ApeEmpleado)
                    .IsRequired()
                    .HasColumnName("apeEmpleado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DirecEmpleado)
                    .IsRequired()
                    .HasColumnName("direcEmpleado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DniEmpleado)
                    .IsRequired()
                    .HasColumnName("dniEmpleado")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmailEmpleado)
                    .HasColumnName("emailEmpleado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomEmpleado)
                    .IsRequired()
                    .HasColumnName("nomEmpleado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassEmpleado)
                    .HasColumnName("passEmpleado")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TlfEmpleado)
                    .HasColumnName("tlfEmpleado")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARGO_EMP");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIST_EMP");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPOUSU_EMP");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK_PRODUCTO");

                entity.HasIndex(e => e.DesProducto)
                    .HasName("UNQ_DES_PROD")
                    .IsUnique();

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.DesProducto)
                    .IsRequired()
                    .HasColumnName("desProducto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.PrecioProducto)
                    .HasColumnName("precioProducto")
                    .HasColumnType("money");

                entity.Property(e => e.StockAct).HasColumnName("stock_act");

                entity.Property(e => e.StockMin).HasColumnName("stock_min");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAT_PROD");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK_TIPOUSUARIO");

                entity.ToTable("Tipo_Usuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomTipoUsuario)
                    .IsRequired()
                    .HasColumnName("nomTipoUsuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

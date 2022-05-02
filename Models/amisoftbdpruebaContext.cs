using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mvctarea.Models
{
    public partial class amisoftbdpruebaContext : DbContext
    {
        public amisoftbdpruebaContext()
        {
        }

        public amisoftbdpruebaContext(DbContextOptions<amisoftbdpruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatosContacto> DatosContactos { get; set; }
        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=amisoftbdprueba;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<DatosContacto>(entity =>
            {
                entity.ToTable("datos_contactos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.PropietarioId, "datos_contactos_propietario_id_unique")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioId, "datos_contactos_usuario_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DireccionCasa)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("direccionCasa");

                entity.Property(e => e.DireccionTrabajo)
                    .HasMaxLength(64)
                    .HasColumnName("direccionTrabajo");

                entity.Property(e => e.EmailEmpresa)
                    .HasMaxLength(64)
                    .HasColumnName("emailEmpresa");

                entity.Property(e => e.EmailPersonal)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("emailPersonal");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PropietarioId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("propietario_id");

                entity.Property(e => e.TelefonoCelular)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("telefonoCelular");

                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(14)
                    .HasColumnName("telefonoFijo");

                entity.Property(e => e.TelefonoTrabajo)
                    .HasMaxLength(14)
                    .HasColumnName("telefonoTrabajo");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("usuario_id");

                entity.HasOne(d => d.Propietario)
                    .WithOne(p => p.DatosContacto)
                    .HasForeignKey<DatosContacto>(d => d.PropietarioId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("datos_contactos_propietario_id_foreign");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.DatosContacto)
                    .HasForeignKey<DatosContacto>(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("datos_contactos_usuario_id_foreign");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.ToTable("migrations");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnType("int(11)")
                    .HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.ToTable("propietarios");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.TipoDocumentoId, "propietarios_tipodocumento_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.TipoDocumentoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("tipoDocumento_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Propietarios)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("propietarios_tipodocumento_id_foreign");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rols");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombre");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.ToTable("rol_usuarios");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.RolId, "rol_usuarios_rol_id_foreign");

                entity.HasIndex(e => e.UsuarioId, "rol_usuarios_usuario_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RolId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("rol_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("usuario_id");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("rol_usuarios_rol_id_foreign");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("rol_usuarios_usuario_id_foreign");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("tipo_documentos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombre");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.TipoDocumentoId, "usuarios_tipodocumento_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.TipoDocumentoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("tipoDocumento_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("usuarios_tipodocumento_id_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class ExperienciaUrbanaContext : DbContext
    {
        public ExperienciaUrbanaContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExperienciaUrbanaContext>();
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
        }

        public ExperienciaUrbanaContext(DbContextOptions<ExperienciaUrbanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActividadesPorHacer> ActividadesPorHacers { get; set; } = null!;
        public virtual DbSet<ComentariosLugare> ComentariosLugares { get; set; } = null!;
        public virtual DbSet<ComentariosRestaurante> ComentariosRestaurantes { get; set; } = null!;
        public virtual DbSet<Lugare> Lugares { get; set; } = null!;
        public virtual DbSet<Restaurante> Restaurantes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosActividade> UsuariosActividades { get; set; } = null!;
        public virtual DbSet<PeliculaSerie> PeliculaSeries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadesPorHacer>(entity =>
            {
                entity.HasKey(e => e.ActividadId)
                    .HasName("PK__Activida__981483F074BDC49B");

                entity.ToTable("ActividadesPorHacer");

                entity.Property(e => e.ActividadId).HasColumnName("ActividadID");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComentariosLugare>(entity =>
            {
                entity.HasKey(e => e.ComentarioId)
                    .HasName("PK__Comentar__F1844958B399EC7F");

                entity.Property(e => e.ComentarioId).HasColumnName("ComentarioID");

                entity.Property(e => e.Comentario).HasColumnType("text");

                entity.Property(e => e.FechaComentario).HasColumnType("date");

                entity.Property(e => e.LugarId).HasColumnName("LugarID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Lugar)
                    .WithMany(p => p.ComentariosLugares)
                    .HasForeignKey(d => d.LugarId)
                    .HasConstraintName("FK__Comentari__Lugar__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComentariosLugares)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comentari__UserI__2F10007B");
            });

            modelBuilder.Entity<ComentariosRestaurante>(entity =>
            {
                entity.HasKey(e => e.ComentarioId)
                    .HasName("PK__Comentar__F1844958D3EFAD3E");

                entity.Property(e => e.ComentarioId).HasColumnName("ComentarioID");

                entity.Property(e => e.Comentario).HasColumnType("text");

                entity.Property(e => e.FechaComentario).HasColumnType("date");

                entity.Property(e => e.RestauranteId).HasColumnName("RestauranteID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Restaurante)
                    .WithMany(p => p.ComentariosRestaurantes)
                    .HasForeignKey(d => d.RestauranteId)
                    .HasConstraintName("FK__Comentari__Resta__286302EC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComentariosRestaurantes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comentari__UserI__29572725");
            });

            modelBuilder.Entity<Lugare>(entity =>
            {
                entity.HasKey(e => e.LugarId)
                    .HasName("PK__Lugares__1BDE0D80D0D0F7AC");

                entity.Property(e => e.LugarId).HasColumnName("LugarID");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.Property(e => e.RestauranteId).HasColumnName("RestauranteID");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });


            

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usuarios__1788CCACC3AB795C");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosActividade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActividadId).HasColumnName("ActividadID");

                entity.Property(e => e.FechaRealizacion).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Actividad)
                    .WithMany()
                    .HasForeignKey(d => d.ActividadId)
                    .HasConstraintName("FK__UsuariosA__Activ__33D4B598");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsuariosA__UserI__32E0915F");
            });

            modelBuilder.Entity<PeliculaSerie>(entity =>
            {
                entity.ToTable("PeliculaSerie");

                entity.Property(e => e.PeliculaSerieId).HasColumnName("PeliculaSerieID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEstreno)
                   .HasMaxLength(15)
                   .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDB : DbContext
    {
        public HotelDB()
            : base("name=HotelDB1")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Caracteristica> Caracteristica { get; set; }
        public virtual DbSet<Caracteristica_Habitacion> Caracteristica_Habitacion { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Facilidad> Facilidad { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelAdministrador> HotelAdministrador { get; set; }
        public virtual DbSet<HotelPublicidad> HotelPublicidad { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .Property(e => e.usuario_Administrador)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.contrasenna_Administrador)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .HasMany(e => e.HotelAdministrador)
                .WithRequired(e => e.Administrador)
                .HasForeignKey(e => e.idAdministrador_HotelAdministradores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Caracteristica>()
                .Property(e => e.descripcion_Caracteristica)
                .IsUnicode(false);

            modelBuilder.Entity<Caracteristica>()
                .HasMany(e => e.Caracteristica_Habitacion)
                .WithRequired(e => e.Caracteristica)
                .HasForeignKey(e => e.idCaracteristica_Caracteristica_Habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.cedula_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nombre_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.apellidos_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.email_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Reservacion)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.idCliente_Reservacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Facilidad>()
                .Property(e => e.id_Facilidad)
                .IsUnicode(false);

            modelBuilder.Entity<Facilidad>()
                .Property(e => e.descripcion_Facilidad)
                .IsUnicode(false);

            modelBuilder.Entity<Facilidad>()
                .Property(e => e.hotel_Facilidad)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.tipo_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.descripcion_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.estado_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.hotel_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .HasMany(e => e.Caracteristica_Habitacion)
                .WithRequired(e => e.Habitacion)
                .HasForeignKey(e => e.idHabitacion_Caracteristica_Habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Habitacion>()
                .HasMany(e => e.Reservacion)
                .WithRequired(e => e.Habitacion)
                .HasForeignKey(e => e.idHabitacion_Reservacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.nombre_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.descripcion_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.comoLlegar_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.telefono_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.email_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Facilidad)
                .WithOptional(e => e.Hotel)
                .HasForeignKey(e => e.hotel_Facilidad);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Habitacion)
                .WithOptional(e => e.Hotel)
                .HasForeignKey(e => e.hotel_Habitacion);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.HotelAdministrador)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.Hotel_HotelAdministradores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.HotelPublicidad)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.Hotel_HotelPublicidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HotelAdministrador>()
                .Property(e => e.Hotel_HotelAdministradores)
                .IsUnicode(false);

            modelBuilder.Entity<HotelPublicidad>()
                .Property(e => e.Hotel_HotelPublicidad)
                .IsUnicode(false);

            modelBuilder.Entity<Publicidad>()
                .Property(e => e.link_Publicidad)
                .IsUnicode(false);

            modelBuilder.Entity<Publicidad>()
                .HasMany(e => e.HotelPublicidad)
                .WithRequired(e => e.Publicidad)
                .HasForeignKey(e => e.idPublicidad_HotelPublicidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservacion>()
                .Property(e => e.idCliente_Reservacion)
                .IsUnicode(false);
        }
    }
}

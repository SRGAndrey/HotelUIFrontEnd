namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDB : DbContext
    {
        public HotelDB()
            : base("name=HotelDB")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Caracteristica> Caracteristica { get; set; }
        public virtual DbSet<Caracteristica_Habitacion> Caracteristica_Habitacion { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Entidad> Entidad { get; set; }
        public virtual DbSet<Entidad_SubEntidad_Imagen> Entidad_SubEntidad_Imagen { get; set; }
        public virtual DbSet<Facilidad> Facilidad { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelAdministrador> HotelAdministrador { get; set; }
        public virtual DbSet<HotelPublicidad> HotelPublicidad { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<SubEntidad> SubEntidad { get; set; }
        public virtual DbSet<Tipo_Habitacion> Tipo_Habitacion { get; set; }
        public virtual DbSet<ImagenesBar> ImagenesBar { get; set; }
        public virtual DbSet<ImagenesCafeteria> ImagenesCafeteria { get; set; }
        public virtual DbSet<ImagenesDescripcion> ImagenesDescripcion { get; set; }
        public virtual DbSet<ImagenesFacilidades> ImagenesFacilidades { get; set; }
        public virtual DbSet<ImagenesHotel> ImagenesHotel { get; set; }
        public virtual DbSet<ImagenesInfantiles> ImagenesInfantiles { get; set; }
        public virtual DbSet<ImagenesJacuzzi> ImagenesJacuzzi { get; set; }
        public virtual DbSet<ImagenesPiscina> ImagenesPiscina { get; set; }
        public virtual DbSet<ImagenesRestaurante> ImagenesRestaurante { get; set; }
        public virtual DbSet<ImagenesSobreNosotros> ImagenesSobreNosotros { get; set; }
        public virtual DbSet<ImagenesTenis> ImagenesTenis { get; set; }

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

            modelBuilder.Entity<Caracteristica_Habitacion>()
                .Property(e => e.tipo_Habitacion_Caracteristica_Habitacion)
                .IsUnicode(false);

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

            modelBuilder.Entity<Entidad>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<Entidad>()
                .HasMany(e => e.Entidad_SubEntidad_Imagen)
                .WithRequired(e => e.Entidad)
                .HasForeignKey(e => e.idEntidad_Entidad_SubEntidad_Imagen)
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
                .Property(e => e.estado_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.tipo_Habitacion_Habitacion)
                .IsUnicode(false);

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
                .Property(e => e.sobreNosotros_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.latitud_Hotel)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.longitud_Hotel)
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
                .HasMany(e => e.HotelAdministrador)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.Hotel_HotelAdministradores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.HotelPublicidad)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.Hotel_HotelPublicidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Tipo_Habitacion)
                .WithOptional(e => e.Hotel)
                .HasForeignKey(e => e.hotel_Tipo_Habitacion);

            modelBuilder.Entity<HotelAdministrador>()
                .Property(e => e.Hotel_HotelAdministradores)
                .IsUnicode(false);

            modelBuilder.Entity<HotelPublicidad>()
                .Property(e => e.Hotel_HotelPublicidad)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .HasMany(e => e.Entidad_SubEntidad_Imagen)
                .WithRequired(e => e.Imagen)
                .HasForeignKey(e => e.idImagen_Entidad_SubEntidad_Imagen)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Rol>()
                .Property(e => e.tipo_Rol)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.descripcion_Rol)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Administrador)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.rol_Administrador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubEntidad>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<SubEntidad>()
                .HasMany(e => e.Entidad_SubEntidad_Imagen)
                .WithRequired(e => e.SubEntidad)
                .HasForeignKey(e => e.idSubEntidad_Entidad_SubEntidad_Imagen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Habitacion>()
                .Property(e => e.nombre_Tipo_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Habitacion>()
                .Property(e => e.descripcion_Tipo_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Habitacion>()
                .Property(e => e.hotel_Tipo_Habitacion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Habitacion>()
                .HasMany(e => e.Caracteristica_Habitacion)
                .WithRequired(e => e.Tipo_Habitacion)
                .HasForeignKey(e => e.tipo_Habitacion_Caracteristica_Habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Habitacion>()
                .HasMany(e => e.Habitacion)
                .WithRequired(e => e.Tipo_Habitacion)
                .HasForeignKey(e => e.tipo_Habitacion_Habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ImagenesBar>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesBar>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesBar>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesCafeteria>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesCafeteria>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesCafeteria>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesDescripcion>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesDescripcion>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesDescripcion>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesFacilidades>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesFacilidades>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesFacilidades>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesHotel>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesHotel>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesHotel>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesInfantiles>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesInfantiles>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesInfantiles>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesJacuzzi>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesJacuzzi>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesJacuzzi>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesPiscina>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesPiscina>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesPiscina>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesRestaurante>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesRestaurante>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesRestaurante>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesSobreNosotros>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesSobreNosotros>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesSobreNosotros>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesTenis>()
                .Property(e => e.descripcion_Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesTenis>()
                .Property(e => e.descripcion_SubEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<ImagenesTenis>()
                .Property(e => e.descripcion_Imagen)
                .IsUnicode(false);
        }
    }
}

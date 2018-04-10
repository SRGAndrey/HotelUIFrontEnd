namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            Facilidad = new HashSet<Facilidad>();
            Habitacion = new HashSet<Habitacion>();
            HotelAdministrador = new HashSet<HotelAdministrador>();
            HotelPublicidad = new HashSet<HotelPublicidad>();
        }

        [Key]
        [StringLength(25)]
        public string nombre_Hotel { get; set; }

        [Required]
        [StringLength(500)]
        public string descripcion_Hotel { get; set; }

        [Required]
        [StringLength(500)]
        public string sobreNosotros_Hotel { get; set; }

        [Required]
        [StringLength(50)]
        public string latitud_Hotel { get; set; }

        [Required]
        [StringLength(50)]
        public string longitud_Hotel { get; set; }

        [Required]
        [StringLength(350)]
        public string comoLlegar_Hotel { get; set; }

        [Required]
        [StringLength(10)]
        public string telefono_Hotel { get; set; }

        public int? aptoPostal_Hotel { get; set; }

        [Required]
        [StringLength(50)]
        public string email_Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facilidad> Facilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitacion> Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelAdministrador> HotelAdministrador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelPublicidad> HotelPublicidad { get; set; }
    }
}

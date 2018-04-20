namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Habitacion()
        {
            Caracteristica_Tipo_Habitacion = new HashSet<Caracteristica_Tipo_Habitacion>();
            Habitacion = new HashSet<Habitacion>();
            Promocion = new HashSet<Promocion>();
        }

        [Key]
        [StringLength(20)]
        public string nombre_Tipo_Habitacion { get; set; }

        [Required]
        [StringLength(500)]
        public string descripcion_Tipo_Habitacion { get; set; }

        public double tarifa_Tipo_Habitacion { get; set; }

        [StringLength(25)]
        public string hotel_Tipo_Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristica_Tipo_Habitacion> Caracteristica_Tipo_Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitacion> Habitacion { get; set; }

        public virtual Hotel Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promocion> Promocion { get; set; }
    }
}

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
            Caracteristica_Habitacion = new HashSet<Caracteristica_Habitacion>();
            Habitacion = new HashSet<Habitacion>();
        }

        [Key]
        [StringLength(15)]
        public string nombre_Tipo_Habitacion { get; set; }

        public double tarifa_Tipo_Habitacion { get; set; }

        [Required]
        [StringLength(500)]
        public string descripcion_Tipo_Habitacion { get; set; }

        [StringLength(25)]
        public string hotel_Tipo_Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristica_Habitacion> Caracteristica_Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitacion> Habitacion { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}

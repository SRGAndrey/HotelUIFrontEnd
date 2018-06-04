namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Caracteristica")]
    public partial class Caracteristica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caracteristica()
        {
            Caracteristica_Tipo_Habitacion = new HashSet<Caracteristica_Tipo_Habitacion>();
        }

        [Key]
        public int id_Caracteristica { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion_Caracteristica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristica_Tipo_Habitacion> Caracteristica_Tipo_Habitacion { get; set; }
    }
}

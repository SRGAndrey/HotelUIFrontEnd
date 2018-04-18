namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imagen")]
    public partial class Imagen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imagen()
        {
            Entidad_SubEntidad_Imagen = new HashSet<Entidad_SubEntidad_Imagen>();
        }

        [Key]
        public int id_Imagen { get; set; }

        public Guid fileID_Imagen { get; set; }

        public byte[] imagen_Imagen { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion_Imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entidad_SubEntidad_Imagen> Entidad_SubEntidad_Imagen { get; set; }
    }
}

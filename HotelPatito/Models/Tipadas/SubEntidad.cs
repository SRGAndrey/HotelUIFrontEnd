namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubEntidad")]
    public partial class SubEntidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubEntidad()
        {
            Entidad_SubEntidad_Imagen = new HashSet<Entidad_SubEntidad_Imagen>();
        }

        [Key]
        public int id_SubEntidad { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion_SubEntidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entidad_SubEntidad_Imagen> Entidad_SubEntidad_Imagen { get; set; }
    }
}

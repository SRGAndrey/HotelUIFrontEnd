namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publicidad")]
    public partial class Publicidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publicidad()
        {
            HotelPublicidad = new HashSet<HotelPublicidad>();
        }

        [Key]
        public int id_Publicidad { get; set; }

        [Required]
        [StringLength(25)]
        public string link_Publicidad { get; set; }

        public Guid fileIDimagen_Publicidad { get; set; }

        public byte[] imagen_Publicidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelPublicidad> HotelPublicidad { get; set; }
    }
}

namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Reservacion = new HashSet<Reservacion>();
        }

        [Key]
        [StringLength(12)]
        public string cedula_Cliente { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre_Cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos_Cliente { get; set; }

        public int tarjeta_Cliente { get; set; }

        [Required]
        [StringLength(35)]
        public string email_Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservacion> Reservacion { get; set; }
    }
}

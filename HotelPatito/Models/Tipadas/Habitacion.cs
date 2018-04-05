namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Habitacion")]
    public partial class Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            Caracteristica_Habitacion = new HashSet<Caracteristica_Habitacion>();
            Reservacion = new HashSet<Reservacion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numero_Habitacion { get; set; }

        [Required]
        [StringLength(9)]
        public string tipo_Habitacion { get; set; }

        [Required]
        [StringLength(350)]
        public string descripcion_Habitacion { get; set; }

        [Required]
        [StringLength(10)]
        public string estado_Habitacion { get; set; }

        public double tarifa { get; set; }

        public Guid fileIDimagen_Habitacion { get; set; }

        public byte[] imagen_Habitacion { get; set; }

        [StringLength(25)]
        public string hotel_Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristica_Habitacion> Caracteristica_Habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservacion> Reservacion { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
